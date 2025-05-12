# Socket-Programming Assignment

## 📖 Overview

This is a simple **client-server console application** built in C# using `.NET`, demonstrating:
- Secure communication using **AES encryption**
- Dictionary-based message parsing
- Timestamp broadcasting from server to client using asynchronous communication

### 👨‍💻 What it does

- The **client** sends an encrypted message asynchronously to the server (e.g., `SetE-Ten`).
- The **server** decrypts the message, checks if the key exists in its predefined dataset, and if found, sends the current timestamp back to the client **N** times (e.g., 10 times for `Ten`), with a 1-second delay between each.
- Communication is encrypted end-to-end.

---

## 🛠️ Tech Stack

| Technology     | Purpose                           |
|----------------|-----------------------------------|
| .NET 6+        | Base framework for app execution  |
| TCP Sockets    | Network communication             |
| AES Encryption | Secure message exchange           |
| Async/Await    | Non-blocking communication logic  |
| C#             | Application logic                 |

---

## 🚀 How to Run the Project

### 🔃 Step 1: Clone the Repository

```bash
git clone https://github.com/rohu0510/socket-assignment.git
cd <project-root-directory>
```

### 🖥️ Step 2: Run the Server

1. Open your terminal or command prompt.
2. Navigate to the `ServerApp` directory (or wherever your server `.csproj` is).
3. Run the following command:

```bash
dotnet run
```

4. When prompted:
   - Enter an IP to bind the server (e.g., `127.0.0.1`)
   - Enter a port (e.g., `5000`)

The server will start listening asynchronously on the provided IP and port.

---

### 💻 Step 3: Run the Client

1. Open another terminal window.
2. Navigate to the `ClientApp` directory.
3. Run the client using:

```bash
dotnet run
```

4. When prompted:
   - Enter the same IP and port you gave in the server
   - Enter your message in the format:  
     `SetA-One`, `SetB-Four`, `SetE-Ten`, etc.

If the key exists, the server will respond with encrypted timestamps, which the client will decrypt and display in real-time using asynchronous reads.

---

## 🧾 Example

```bash
Client > Enter Server IP (e.g., 127.0.0.1): 127.0.0.1
Client > Enter Server Port (e.g., 5000): 5000
Client > Enter message to send (e.g., SetA-One): SetE-Ten
```

```bash
Server Response:
12-05-2025 14:25:31
12-05-2025 14:25:32
...
```

---

## 📦 AES Encryption

The AES logic is already implemented in a separate file named `AesEncryption.cs` and is shared across both the server and client apps for consistency.

---

## 📝 Notes

- Ensure both client and server apps are referencing the same AES encryption logic.
- The IP and port **must match** between client and server for successful communication.
- To stop the server, press `Ctrl + C` in the terminal.
- The client and server now both use asynchronous socket communication for better scalability and responsiveness.

---

## 📁 Project Structure

```
/Socket-Programming
│
├── ClientApp
│   ├── Program.cs
|   ├── ClientService.cs
│   └── AesEncryption.cs
│
├── ServerApp
│   ├── Program.cs
|   ├── ClientHandler.cs
│   ├── DataStore.cs
│   └── AesEncryption.cs
```

---
