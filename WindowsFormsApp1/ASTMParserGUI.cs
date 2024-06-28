using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using ASTMParser;
using MongoDB.Bson;
using MongoDB.Driver;
using WindowsFormsApp1;

namespace ASTMViewer
{
    public partial class ASTMParserGUI : Form
    {
        hex_kq f1;
        public ASTMParserGUI(hex_kq f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        List<ASTM_Message> messages = new List<ASTM_Message>();
        private static IMongoCollection<BsonDocument> _collection;

        void populateData(ASTM_Record r, TreeNode n, int fromIdx = 1)
        {
            for (int fi = fromIdx; fi <= r.fieldsCount(); fi++)
            {
                if (r.fieldValue(fi) != null && r.fieldValue(fi).Length > 0)
                    n.Nodes.Add(r.fieldName(fi) + ":\t" + r.fieldValue(fi));
            }
            if (r.comments() != null)
            {
                foreach (ASTM_Comment c in r.comments())
                {
                    TreeNode curCommentNode = n.Nodes.Add("Comment");
                    for (int fi = fromIdx; fi <= c.fieldsCount(); fi++)
                    {
                        if (c.fieldValue(fi) != null && c.fieldValue(fi).Length > 0)
                            curCommentNode.Nodes.Add(c.fieldName(fi) + ":\t" + c.fieldValue(fi));
                    }
                }
            }
            if (r.manufacturerInfo() != null)
            {
                foreach (ASTM_Manufacturer m in r.manufacturerInfo())
                {
                    TreeNode curManNode = n.Nodes.Add("Manufacturer Info");
                    for (int fi = fromIdx; fi <= m.fieldsCount(); fi++)
                    {
                        if (m.fieldValue(fi) != null && m.fieldValue(fi).Length > 0)
                            curManNode.Nodes.Add(m.fieldName(fi) + ":\t" + m.fieldValue(fi));
                    }
                }
            }
        }

        void populateData()
        {
            messagesData.Nodes.Clear();
            foreach (ASTM_Message m in messages)
            {
                TreeNode curMessageNode = messagesData.Nodes.Add("Message");
                populateData(m, curMessageNode, 3);

                foreach (ASTM_Patient p in m.patientRecords)
                {
                    TreeNode curPatientNode = curMessageNode.Nodes.Add("Patient");
                    populateData(p, curPatientNode, 3);

                    foreach (ASTM_Order o in p.orderRecords)
                    {
                        TreeNode curOrderNode = curPatientNode.Nodes.Add("Order");
                        populateData(o, curOrderNode, 3);

                        foreach (ASTM_Result r in o.resultRecords)
                        {
                            TreeNode curResultNode = curOrderNode.Nodes.Add("Result");
                            populateData(r, curResultNode, 3);
                        }
                    }
                }

                foreach (ASTM_Request q in m.requestRecords)
                {
                    TreeNode curRequestNode = curMessageNode.Nodes.Add("Request Order");
                    populateData(q, curRequestNode, 3);
                }

                foreach (ASTM_Scientific s in m.scientificRecords)
                {
                    TreeNode curScientificNode = curMessageNode.Nodes.Add("Scientific");
                    populateData(s, curScientificNode, 3);
                }
            }
            messagesData.ExpandAll();
        }

        private BsonDocument ConvertToBsonDocument(TreeNode node)
        {
            BsonDocument bsonDoc = new BsonDocument();
            int index = node.Text.IndexOf(':');

            if (index != -1)
            {
                string key = node.Text.Substring(0, index).Trim();
                string value = node.Text.Substring(index + 1).Trim();
                bsonDoc.Add(key, value);
            }

            var resultsArray = new BsonArray();
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Text.StartsWith("Result") == true && childNode.Text.StartsWith("Result Abnormal Flags") == false)
                {
                    resultsArray.Add(ConvertToBsonDocument(childNode));
                }
                else
                {
                    var childBsonDoc = ConvertToBsonDocument(childNode);
                    foreach (var element in childBsonDoc.Elements)
                    {
                        bsonDoc.Add(element.Name, element.Value);
                    }
                }
            }

            if (resultsArray.Count > 0)
            {
                bsonDoc.Add("Results", resultsArray);
            }

            return bsonDoc;
        }

        private BsonDocument CreateBsonDocument(TreeNodeCollection nodes)
        {
            BsonDocument document = new BsonDocument();

            foreach (TreeNode node in nodes)
            {
                if (node.Text.StartsWith("Message"))
                {
                    BsonDocument messageDoc = new BsonDocument();
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Text.StartsWith("Result"))
                        {
                            var resultArray = new BsonArray();
                            foreach (TreeNode resultNode in childNode.Nodes)
                            {
                                resultArray.Add(ConvertToBsonDocument(resultNode));
                            }
                            messageDoc.Add("Results", resultArray);
                        }
                        else
                        {
                            var childBsonDoc = ConvertToBsonDocument(childNode);
                            foreach (var element in childBsonDoc.Elements)
                            {
                                messageDoc.Add(element.Name, element.Value);
                            }
                        }
                    }
                    document.Add("MessageData", messageDoc);
                }
            }

            return document;
        }

        public void clear()
        {
            messages.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void messagesData_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void ASTMParserGUI_Load(object sender, EventArgs e)
        {
            astmData.Text = f1.txtkq.Text;
            parsed();
        }

        private void astmData_TextChanged(object sender, EventArgs e)
        {
        }

        private void parsed()
        {
            clear();

            Parser parser = new Parser();
            parser.parse(this.astmData.Text, ref messages);
            populateData();

            var bsonDocument = CreateBsonDocument(messagesData.Nodes);

            var client = new MongoClient("mongodb+srv://huukienkame:huukien1012@cluster0.6g1m0bb.mongodb.net/");
            var database = client.GetDatabase("hl7_db");
            _collection = database.GetCollection<BsonDocument>("hl7_messages");

            _collection.InsertOne(bsonDocument);
        }

        private void astmData_TextChanged_1(object sender, EventArgs e)
        {
        }


    }
}
