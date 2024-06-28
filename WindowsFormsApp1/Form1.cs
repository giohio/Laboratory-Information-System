using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using NHapi.Base.Parser;
using NHapi.Model.V25.Message;
using MongoDB.Bson.Serialization;
using System.Diagnostics;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NHapi.Base.PreParser;
using ASTMParser;
using ASTMViewer;


namespace WindowsFormsApp1
{
    public partial class hex_kq : Form
    {
        SerialPort P = new SerialPort(); // Khai báo 1 Object SerialPort mới.

        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        ManagementEventWatcher deviceInsertedWatcher;
        ManagementEventWatcher deviceRemovedWatcher;
        int cnt = 0;
        private Timer timer;
        private bool comDisconnectedMessageShown = false;
        private static IMongoCollection<BsonDocument> _collection;
        private string Hl7_mes = "";
        private static bool Boolean = false;
        List<ASTM_Message> messages = new List<ASTM_Message>();
        public hex_kq()
{
            InitializeComponent();
            Dtr.Enabled = false;
            Rts.Enabled = false;
            string[] ports = SerialPort.GetPortNames();
            // Thêm toàn bộ các COM đã tìm được vào combox cbCom
            cbCom.Items.AddRange(ports);


            P.PinChanged += new SerialPinChangedEventHandler(PinChangedHandler);



            P.ReadTimeout = 1000;
            P.DataReceived += new SerialDataReceivedEventHandler(HexReceive);
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200",
            "38400", "57600", "115200" };
            cbRate.Items.AddRange(BaudRate);
            string[] Databits = { "6", "7", "8" };
            cbBits.Items.AddRange(Databits);
            //Cho Parity
            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);
            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2" };
            cbBit.Items.AddRange(stopbit);
            string[] HandshakeOptions = { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" };
            cbHandshake.Items.AddRange(HandshakeOptions);
            cbHandshake.SelectedIndexChanged += cbHandshake_SelectedIndexChanged;
            btNgat.Enabled = false;
            timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
            InitializeDeviceInsertedWatcher();
            InitializeDeviceRemovedWatcher();
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close(); // Nếu đang mở Port thì phải đóng lại
            }
            P.PortName = cbCom.SelectedItem.ToString();
        }

        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.BaudRate = Convert.ToInt32(cbRate.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void cbBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.DataBits = Convert.ToInt32(cbBits.Text);
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            // Với thằng Parity hơn lằng nhằng. Nhưng cũng OK thôi. ^_^
            switch (cbParity.SelectedItem.ToString())
            {
                case "Odd":
                    P.Parity = Parity.Odd;
                    break;
                case "None":
                    P.Parity = Parity.None;
                    break;
                case "Even":
                    P.Parity = Parity.Even;
                    break;
            }
        }

        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cbBit.SelectedItem.ToString())
            {
                case "1":
                    P.StopBits = StopBits.One;
                    break;
                case "1.5":
                    P.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    P.StopBits = StopBits.Two;
                    break;
            }
        }
        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            InputData = P.ReadExisting();
            if (InputData != String.Empty)
            {
                SetText(InputData);
                SetHex(ConvertTextToHex(InputData));
            }
        }

        private void HexReceive(object obj, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = P.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            P.Read(buffer, 0, bytesToRead);
            string texthexData = BitConverter.ToString(buffer).Replace("-", " ");
            string hexData = BitConverter.ToString(buffer).Replace("-", ""); // Convert bytes to hexadecimal string
            if (!string.IsNullOrEmpty(hexData))
            {
                SetHex(texthexData);
                SetText(ConvertHexToText(hexData));
            }
            Mllp_Hl7(hexData);
            cnt++;
            SetTime(cnt);
            writeFolder(hexData);
        }
        private void Mllp_Hl7(string hexData)
        {
            try
            {
                if (hexData.Substring(0, 2) == "0B")
                {
                    Hl7_mes += hexData;
                }
                if (Hl7_mes != "")
                {
                    if (Hl7_mes.Substring(0, 2) == "0B" && Hl7_mes.Substring(Math.Max(0, Hl7_mes.Length - 4)) != "1C0D")
                    {
                        Hl7_mes += hexData;
                    }
                    else if (Hl7_mes.Substring(Math.Max(0, Hl7_mes.Length - 4)) == "1C0D")
                    {
                        Hex_Ack(Hl7_mes);
                        Boolean = true;
                    }
                }
            }
            catch (Exception ex)
            {
                P.Write("Lỗi");
            }
        }
        private void writeFolder(string hexData)
        {
            string folderPath = txtFolder.Text;
            string filePath = Path.Combine(folderPath, "Message.txt");
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                File.AppendAllText(filePath, "Ngày " + DateTime.Now.ToString("yyyy:MM:dd:hh:mm") + ":\r" + "Lần" + cnt + ":\r" + "Hex Data: " + hexData + Environment.NewLine);
                File.AppendAllText(filePath, "Text Data: " + ConvertHexToText(hexData) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetTime(int cnt)
        {
            if (this.txtTime.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate { SetTime(cnt); });
            }
            else
            {
                this.txtTime.Text = cnt.ToString();
            }
        }
        private void SetText(string text)
        {
            if (this.txtkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtkq.Text += text;
            }
        }

        private void SetHex(string hexData)
        {
            if (this.hexkq.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetHex);
                this.Invoke(d, new object[] { hexData });
            }
            else
            {
                this.hexkq.Text += hexData+"\r\n";
            }
        }

        private string ConvertTextToHex(string text)
        {
            StringBuilder hex = new StringBuilder(text.Length * 2);
            foreach (char c in text)
            {
                hex.AppendFormat("{0:X2}", (int)c);
            }
            return hex.ToString();
        }

        private string ConvertHexToText(string hex)
        {
            StringBuilder text = new StringBuilder(hex.Length / 2);
            for (int i = 0; i < hex.Length; i += 2)
            {
                text.Append((char)Convert.ToByte(hex.Substring(i, 2), 16));
            }
            return text.ToString();
        }


        private void btSend_Click(object sender, EventArgs e)
        {
            {
                if (P.IsOpen)
                {
                    if (txtSend.Text == "") MessageBox.Show("Chưa có dữ liệu!","Thông Báo");
                    else P.Write(txtSend.Text);
                }
                else MessageBox.Show("COM chưa mở.", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSend.Clear();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            cbCom.SelectedIndex = 0; // chọn COM được tìm thấy đầu tiên
            cbRate.SelectedIndex = 3; // 9600
            cbBits.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbBit.SelectedIndex = 0; // None
                                     // Hiện thị Status cho Pro tí
            cbHandshake.SelectedIndex = 0;
            status.Text = "Hãy chọn 1 cổng COM để kết nối.";
        }

        private void btKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                P.Open();
                btNgat.Enabled = true;
                btKetNoi.Enabled = false;
                cbCom.Enabled = false;
                cbBit.Enabled = false;
                cbParity.Enabled = false;
                cbHandshake.Enabled = false;
                cbRate.Enabled = false;
                cbBits.Enabled = false;
                Dtr.Enabled = true;
                Rts.Enabled = true;
                // Hiện thị Status
                status.Text = "Đang kết nối với cổng " +cbCom.SelectedItem.ToString();
                if (comDisconnectedMessageShown)
                {
                    comDisconnectedMessageShown = false;
                }
                timer1.Start();
                if (!P.RtsEnable && !P.CtsHolding && !P.DtrEnable && !P.CDHolding && !P.DsrHolding)
                {
                    LogCombinedStatusToFile(P.RtsEnable, P.CtsHolding, P.DtrEnable, P.CDHolding, P.DsrHolding);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được.", "Thửlại",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btNgat_Click(object sender, EventArgs e)
        {
            //timer2.Stop();
            P.Close();
            btKetNoi.Enabled = true;
            btNgat.Enabled = false;
            cbCom.Enabled = true;
            cbBit.Enabled = true;
            cbParity.Enabled = true;
            cbHandshake.Enabled = true;
            cbRate.Enabled = true;
            cbBits.Enabled = true;
            status.Text = "Đã Ngắt Kết Nối";
            timer1.Stop();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn thực sự muốn thoát","Testing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                MessageBox.Show("Cảm ơn bạn đã sử dụng chương trình","Testing");
               
                this.Close();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtkq.Text = "";
            hexkq.Text = "";
            txtSend.Text = "";
        }

        private void cbHandshake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            // Set the handshake option
            switch (cbHandshake.SelectedItem.ToString())
            {
                case "None":
                    P.Handshake = Handshake.None;
                    break;
                case "XOnXOff":
                    P.Handshake = Handshake.XOnXOff;
                    break;
                case "RequestToSend":
                    P.Handshake = Handshake.RequestToSend;
                    break;
                case "RequestToSendXOnXOff":
                    P.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
            }
        }

        private void txtkq_TextChanged(object sender, EventArgs e)
        {

        }

        private void hexkq_TextChanged(object sender, EventArgs e)
        {

        }
        private void Hex_Ack(String hexData)
        {

            try
            {

            }
            catch (Exception exception)
            {

            }
            finally
            {
                ACK acknowledgement = new ACK(); // create an ACK message
                PipeParser pipeParser = new PipeParser();
                string ackMessage = pipeParser.Encode(acknowledgement); // produces => MSH|^~\&|||||||ACK|||2.3
                ackMessage = ((char)11).ToString() + ackMessage + ((char)28).ToString() + ((char)13).ToString();
                byte[] ackMessageBytes = Encoding.UTF8.GetBytes(ackMessage);

                //P.Write(ackMessageBytes, 0, ackMessageBytes.Length);
            }
        }
        private void Parse(string Hl7mes)
        {
            Hl7mes = Hl7mes.Substring(2, Hl7mes.Length - 3 - 4 + 1);
            Hl7mes.Replace("0D", "");
            string[] Departments = {
            "AMB", "PSY", "PPS", "REH", "PRE",
            "ISO", "OBG", "PIN", "INT", "SUR",
            "PSI", "EDI", "CAR", "NBI", "CCR",
            "PED", "EMR", "OBS", "WIC", "PHY",
            "ALC", "FPC", "CHI", "CAN", "NAT",
            "OTH"
            };
            string textmes = ConvertHexToText(Hl7mes);
            textmes += $"\r\nPID|1|{txtCCCD.Text}|||" + txtHoten.Text.Replace(" ", "^") + "||" + txtNtn.Text + '|' + txtGt.Text + "|||||||" + $"\r\nPV1|||{Departments[cbKhoa.SelectedIndex]}||||||";

            // Debug: Log the constructed HL7 message
            Debug.WriteLine($"Constructed HL7 Message: {textmes}");
            var ourPipeParser = new PipeParser();
            try
            {
                var hl7Message = ourPipeParser.Parse(textmes);

                // Convert the HL7 message from XML to JSON
                var ourXmlParser = new DefaultXMLParser();
                var xmlMessage = ourXmlParser.Encode(hl7Message);
                var jsonText = ConvertXmlToJson(xmlMessage);
                if (jsonText != null )
                {
                    var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(jsonText); // Deserialize JSON string to BSON document

                    // Connect to MongoDB
                    var client = new MongoClient("mongodb+srv://caothihoaithuongt66:LHWvnvPVQrhsdvDG@cluster0.8vl7mdu.mongodb.net/hl7_db?retryWrites=true&w=majority&appName=Cluster0"); // Update with your MongoDB connection string
                    var database = client.GetDatabase("hl7_db"); // Update with your database name
                    _collection = database.GetCollection<BsonDocument>("hl7_messages"); // Update with your collection name

                    // Insert the BSON document into MongoDB
                    _collection.InsertOne(bsonDocument);

                }
                else
                {
                    Debug.WriteLine("Lỗi");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Lỗi");
            }
        }
        private static string ConvertXmlToJson(string xmlMessage)
        {
            try
            {
                var xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.LoadXml(xmlMessage);
                return JsonConvert.SerializeXmlNode(xmlDocument);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void Dtr_CheckedChanged(object sender, EventArgs e)
        {
            if (P != null)
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox != null)
                {
                    P.DtrEnable = checkBox.Checked;
                }
            }
        }

        private void Rts_CheckedChanged(object sender, EventArgs e)
        {
            if (P != null)
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox != null)
                {
                    P.RtsEnable = checkBox.Checked;
                }
            }
        }





        private void InitializeDeviceInsertedWatcher()
        {
            deviceInsertedWatcher = new ManagementEventWatcher();
            deviceInsertedWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            deviceInsertedWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            deviceInsertedWatcher.Start();
        }

        private void InitializeDeviceRemovedWatcher()
        {
            deviceRemovedWatcher = new ManagementEventWatcher();
            deviceRemovedWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            deviceRemovedWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            deviceRemovedWatcher.Start();
        }

        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            // Update COM port list when a new port is inserted
            UpdateComPorts();
        }

        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            // Update COM port list when a port is removed
            UpdateComPorts();
            if (!comDisconnectedMessageShown)
            {
                MessageBox.Show("Cổng kết nối đã bị rút ra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comDisconnectedMessageShown = true;
            }
        }

        private void UpdateComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateComPorts));
            }
            else
            {
                cbCom.Items.Clear();
                cbCom.Items.AddRange(ports);

                // If selected port is no longer available, clear selection
                if (!cbCom.Items.Contains(P.PortName))
                {
                    P.Close();
                    cbCom.SelectedIndex = 0;
                    btKetNoi.Enabled = true;
                    btNgat.Enabled = false;
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the txtTime TextBox with the current time
            txtDate.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtFolder_TextChanged(object sender, EventArgs e)
        {

        }








        private void PinChangedHandler(object sender, SerialPinChangedEventArgs e)
        {
            if (e.EventType == SerialPinChange.CtsChanged)
            {
                bool ctsStatus = P.CtsHolding;

                if (ctsStatus != isCircleGreen)
                {
                    UpdateCircleState(ctsStatus);
                    CTSStatus.Invalidate();
                }
            }
            else if (e.EventType == SerialPinChange.DsrChanged)
            {
                bool dsrStatus = P.DsrHolding;

                if (dsrStatus != isCircleDSRGreen)
                {
                    UpdateDSRCircleState(dsrStatus);
                    DSRStatus.Invalidate();
                }
            }
            else if (e.EventType == SerialPinChange.CDChanged)
            {
                bool cdStatus = P.CDHolding;

                if (cdStatus != isCircleCDGreen)
                {
                    UpdateCDCircleState(cdStatus);
                    CDStatus.Invalidate();
                }
            }
        }




        //CTS STATUS

        private bool isCircleGreen = false;
        private void CTSStatus_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = CTSStatus.Width;
            int height = CTSStatus.Height;

            if (isCircleGreen)
            {
                using (SolidBrush brush = new SolidBrush(Color.Green))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
        }

        private void UpdateCircleState(bool isGreen)
        {
            isCircleGreen = isGreen;
        }


        // DSR Status

        private bool isCircleDSRGreen = false;
        private void DSRStatus_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = DSRStatus.Width;
            int height = DSRStatus.Height;

            if (isCircleDSRGreen)
            {
                using (SolidBrush brush = new SolidBrush(Color.Green))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
        }

        private void UpdateDSRCircleState(bool isGreen)
        {
            isCircleDSRGreen = isGreen;
        }


        // CD Status

        private bool isCircleCDGreen = false;
        private void CDStatus_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = CDStatus.Width;
            int height = CDStatus.Height;

            if (isCircleCDGreen)
            {
                using (SolidBrush brush = new SolidBrush(Color.Green))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, 0, 0, width, height);
                }
            }
        }

        private void UpdateCDCircleState(bool isGreen)
        {
            isCircleCDGreen = isGreen;
        }




        //Luu file
        private bool previousRTSStatus = false;
        private bool previousCTSStatus = false;
        private bool previousDTRStatus = false;
        private bool previousCDStatus = false;
        private bool previousDSRStatus = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                bool currentRTSStatus = P.RtsEnable;
                bool currentCTSStatus = P.CtsHolding;
                bool currentDTRStatus = P.DtrEnable;
                bool currentCDStatus = P.CDHolding;
                bool currentDSRStatus = P.DsrHolding;
                UpdateUI(currentCTSStatus, currentCDStatus, currentDSRStatus);


                // Lưu khi trạng thái thay đổi
                if (currentRTSStatus != previousRTSStatus || currentCTSStatus != previousCTSStatus || currentDTRStatus != previousDTRStatus || currentCDStatus != previousCDStatus || currentDSRStatus != previousDSRStatus)
                {
                    previousRTSStatus = currentRTSStatus;
                    previousCTSStatus = currentCTSStatus;
                    previousDTRStatus = currentDTRStatus;
                    previousCDStatus = currentCDStatus;
                    previousDSRStatus = currentDSRStatus;
                    LogCombinedStatusToFile(currentRTSStatus, currentCTSStatus, currentDTRStatus, currentCDStatus, currentDSRStatus);
                }
            }
            
        }

        private DateTime timerStartTime;

        private void LogCombinedStatusToFile(bool rtsStatus, bool ctsStatus, bool dtrStatus, bool cdStatus, bool dsrStatus)
        {
            string folderPath = txtFolder.Text; // Sử dụng đường dẫn từ txtFolder
            string logFileName = "CombinedStatusLog.txt"; // Tên tập tin log
            string logFilePath = Path.Combine(folderPath, logFileName); // Đường dẫn và tên tập tin để lưu trạng thái

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                TimeSpan elapsedTime = DateTime.Now - timerStartTime;

                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-Time: " + elapsedTime.TotalMilliseconds + "ms, RTS Status - " + (rtsStatus ? "Enabled" : "Disabled") + ", CTS Status - " + (ctsStatus ? "Enabled" : "Disabled") + ", DTR Status - " + (dtrStatus ? "Enabled" : "Disabled") + ", CD Status - " + (cdStatus ? "Enabled" : "Disabled") + ", DSR Status - " + (dsrStatus ? "Enabled" : "Disabled"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging combined RTS, CTS, DTR, CD, and DSR status: " + ex.Message);
            }
        }

        private void UpdateUI(bool ctsStatus, bool cdStatus, bool dsrStatus)
        {

            isCircleGreen = ctsStatus;
            isCircleCDGreen = cdStatus;
            isCircleDSRGreen = dsrStatus;

            CTSStatus.Invalidate();
            CDStatus.Invalidate();
            DSRStatus.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSendHex_Click(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                if (txtSendHex.Text == "")
                {
                    MessageBox.Show("Chưa có dữ liệu!", "Thông Báo");
                }
                else
                {
                    string hexData = txtSendHex.Text.Trim(); // Get the hexadecimal data from the textbox

                    // Remove any spaces from the hexadecimal data
                    hexData = hexData.Replace(" ", "");

                    // Convert the hexadecimal string to bytes
                    byte[] bytes = new byte[hexData.Length / 2];
                    for (int i = 0; i < hexData.Length; i += 2)
                    {
                        bytes[i / 2] = Convert.ToByte(hexData.Substring(i, 2), 16);
                    }

                    // Send the bytes over the serial port
                    P.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                MessageBox.Show("COM chưa mở.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtSendHex.Clear();
        }
        

        private void btXem_Click(object sender, EventArgs e)
        {
            ASTMParserGUI f2 = new ASTMParserGUI(this);
            f2.ShowDialog();
        }

        private void btHt_Click(object sender, EventArgs e)
        {
            if (Boolean == true)
            {
                Parse(Hl7_mes);
                Hl7_mes = "";
            }
        }

        private void bt_sendack_Click(object sender, EventArgs e)
        {
            string ackMessage = ((char)06).ToString();
            byte[] ackMessageBytes = Encoding.UTF8.GetBytes(ackMessage);

            P.Write(ackMessageBytes, 0, ackMessageBytes.Length);
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
