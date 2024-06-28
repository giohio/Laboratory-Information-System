| Supported Targets | Rs-232 |
| ----------------- | -------- |

# Lis Sample Descriptor

This example is demonstrating how to set up Rs-232 app to get data from laboratory devices and then store data into mongdb.

## How to use example

### Hardware Required

- Any board with USB port and has Com port driver

### Configure the project

There are two ways to set up app - using setup.exe and in-code

#### In-code setting up

Run the solution code in the folder (the only .sln file in folder) with visual studio

#### Installation

If you want to set up the Lis app using .exe file:

1. Open the setup folder, then open the debug folder
2. Open the setup.msi or setup.exe (both will work)
3. Setup and install the application just by clicking next and the app will automatically install

### How to use the app
Step 1: Establish Connection with Medical Devices
The program initiates with selecting the COM port and setting the appropriate Baud Rate,... to establish a stable connection with medical devices. Accurate selection of COM port, Baud Rate and others to ensure reliable transmission of data from medical devices.
Step 2: Receive Laboratory Test Data from Medical Devices
Upon successful connection establishment, the application waits for medical devices to analyze test samples. These devices conduct necessary tests and transmit the test results as data to the application.
Step 3: Display Result Data
Upon receiving data from medical devices, the application automatically displays the data in text and hexadecimal formats. This allows healthcare staff to verify the accuracy of raw data before proceeding to further steps.
Step 4: Decode HL7 Messages and Generate PDF Files
Laboratory test results are often transmitted as HL7 (Health Level Seven) messages. The application automatically decodes these messages and converts them into readable text format. Subsequently, this information is compiled into a PDF file. Doctors can easily access and review test results by clicking the "Xem" button on the application interface.
Step 5: Input Patient Information and Department
While awaiting test results, doctors can input detailed patient information, including name, age, gender, and relevant details. Additionally, physicians can select the appropriate department for the patient. This step ensures accurate and organized management of patient information.
Step 6: Completion and Update Information in MongoDB
Upon completion of the information input and receipt of test results, physicians can press the "Hoàn thành" button to update all patient information and examination results into the MongoDB database. This ensures that all information is securely stored and easily accessible when needed.

### How to use the app to test data
Step 1: You need to setup Hercules app to send the test data (You can see how to download in this link:https://machdienlythu.vn/huong-dan-tai-va-su-dung-hercules-terminal/)
Step 2: You might have to set up virtual port to set up connection between apps (Dowload linkhttps://www.virtual-serial-port.org/, you can have 14 days trial when install)
Step 3: Set up a pair port in the virtual port app
Step 4: Set up the selection of pair Com port and the same selection of others setting.
Step 5: Send this example message: 0B4D53487C5E7E5C267C4C49537C4C4142317C4849537C484F5350317C3230323230343033313230307C7C4F52555E5230317C3132333435363738397C507C322E350D4F52437C52457C3132333435367C7C3132333435367C434D0D4F42527C317C3132333435367C37383930313233345E4C49537C3030313233345E426C6F6F6420746573747C7C7C3230323230343033313133307C7C7C7C7C7C7C3132333435367C467C7C7C7C0D4F42587C317C4E4D7C474C555E476C75636F73657C7C3130307C6D672F644C7C37302D3131307C7C487C7C7C460D4F42587C327C4E4D7C4847425E48656D6F676C6F62696E7C7C31347C672F644C7C31332D31377C7C4E7C7C7C460D4F42587C337C4E4D7C43484F4C5E43686F6C65737465726F6C7C7C3230307C6D672F644C7C3C3230307C7C487C7C7C461C0D in hex form in Hercules app and the Lis app will receive it.
