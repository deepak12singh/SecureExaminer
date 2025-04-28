# 📚 SecureExaminer

**SecureExaminer** ek Windows application hai, jo online exam ke liye **Secure Kiosk Mode Browser** create karta hai.  
Is app ka use karke students sirf exam page access kar sakte hain — aur Windows ke shortcuts (Alt+Tab, WinKey, Ctrl+Alt+Del) ko disable kar diya jata hai.

---

## ✨ Features

- 🔒 Fullscreen Kiosk Mode
- 💽 Embedded Chromium Browser (via CefSharp)
- 🚫 Disable Context Menu (No right-click)
- 😷 Block Keyboard shortcuts:
  - Alt + Tab
  - Windows Key
  - Ctrl + Esc
- 🔑 Secure Exit via Password (optional - can be added)
- 🛡️ Minimalistic & Secure environment for online exams

---

## 🛠️ Technologies Used

- C# (.NET Framework 4.7.2 or higher)
- Windows Forms
- CefSharp.WinForms (Chromium Embedded Framework)

---

## 📦 Project Structure

```
SecureExaminer/
 ├── App.config
 ├── CustomMenuHandler.cs
 ├── CustomRequestHandler.cs
 ├── KeyboardHook.cs
 ├── MainForm.cs
 ├── MainForm.Designer.cs
 ├── MainForm.resx
 ├── Program.cs
 ├── packages.config
```

---

## 🚀 How to Run

1. Clone this repository:

   ```bash
   git clone https://github.com/yourusername/SecureExaminer.git
   cd SecureExaminer
   ```

2. Open `SecureExaminer.sln` in **Visual Studio 2019/2022**.

3. Install Dependencies:
   
   Go to **Tools → NuGet Package Manager → Manage NuGet Packages**  
   Install:

   - `CefSharp.WinForms`

4. Build the project (`Ctrl + Shift + B`).

5. Run the app (`F5`).

6. On launch, the app will ask for the **Exam URL**.

---

## 📷 Screenshots

> (Add screenshots of your app running here if you want later.)

---

## 🧐 How It Works

- When the app starts:
  - It prompts for an **exam URL**.
  - Locks the screen in **fullscreen mode**.
  - Loads the exam page inside a **Chromium browser**.
  - Blocks Windows shortcuts and context menu.
- The student can only interact with the exam page.

---

## ❗ Note

- Admin/Teachers should pre-share the correct Exam URL.
- Password-protected exit system can be added for extra security.
- System-level blocking (Ctrl+Alt+Del) requires additional system settings which are not handled by regular Windows Forms apps.

---

## 📜 License

This project is open source and free to use for educational purposes.

---

# 💍 Credits

Developed with ❤️ using C#, CefSharp and Windows Forms.

