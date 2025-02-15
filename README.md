
# Task Manager (iti project)

## 📌 Overview
Task Manager هو تطبيق بسيط لإدارة المهام، يتيح لك إضافة المهام، تعديلها، وحذفها، مع تخزينها في ملف نصي للحفاظ على البيانات بين الجلسات.

## ⚙️ Features
- إضافة المهام مع التحقق من عدم تكرارها.
- تعديل المهام الموجودة.
- حذف المهام بسهولة.
- عرض جميع المهام المخزنة.
- حفظ المهام تلقائيًا في ملف نصي.
- إشعارات عند التحديثات (إضافة/تعديل/حذف المهام).
- دعم سلاسل المفوضين (Delegate Chains) لتنفيذ إشعارات متعددة مثل الطباعة على الشاشة وإرسال البريد الإلكتروني.

## 🛠️ Technologies Used
- **Language**: C#
- **Framework**: .NET
- **Storage**: File-based (tasks.txt)

## 🚀 How to Use

1. **تشغيل البرنامج**:
   قم بتشغيل `Program.cs` داخل بيئة تشغيل C# مثل Visual Studio أو .NET CLI.

2. **إدخال الأوامر من خلال القائمة التفاعلية**:
   بعد تشغيل البرنامج، ستظهر لك قائمة تحتوي على الخيارات التالية:
   - `1` لإضافة مهمة.
   - `2` لتعديل مهمة.
   - `3` لحذف مهمة.
   - `4` لعرض جميع المهام.
   - `5` للخروج من البرنامج.

3. **إضافة مهمة جديدة**:
   ```csharp
   Enter task name: Study C#
   ```

4. **تعديل اسم مهمة موجودة**:
   ```csharp
   Enter old task name: Study C#
   Enter new task name: Practice C#
   ```

5. **حذف مهمة**:
   ```csharp
   Enter task name to remove: Practice C#
   ```

6. **عرض المهام المخزنة**:
   ```csharp
   Current tasks:
   - Learn Design Patterns
   - Build a To-Do App
   ```

## 📂 File Storage
يتم تخزين المهام في ملف `tasks.txt` تلقائيًا للحفاظ على البيانات بين الجلسات.

## 📢 Event Handling
يستخدم التطبيق `TaskUpdated` لإرسال إشعارات عند التعديلات، مع دعم سلاسل المفوضين (Delegate Chains) لتنفيذ مهام متعددة مثل الإشعارات والطباعة وإرسال البريد الإلكتروني:
```csharp
manager.TaskUpdated += message => Console.WriteLine("Notification: " + message);
manager.TaskUpdated += message => Console.WriteLine("Sending email: " + message);
```

## 🏗️ Task Class
يتم تمثيل المهمة داخل التطبيق من خلال الكلاس `Task`:
```csharp
internal class Task
{
    public string Name { get; set; }
    public Task(string name)
    {
        Name = name;
    }
}
```

## 🔹 C# Concepts Used
هذا المشروع يستخدم عدة مفاهيم من C#، منها:
- **الكلاسات (Classes)** - تعريف `Task` و `TaskManager` و `Program`.
- **الخصائص (Properties)** - مثل `public string Name { get; set; }` داخل كلاس `Task`.
- **المُنشئات (Constructors)** - مثل `public Task(string name)`.
- **القوائم (Lists)** - تم استخدام `List<Task>` لتخزين المهام.
- **عمليات الملفات (File Operations)** - تم استخدام `File.WriteAllLines` و `File.ReadAllLines`.
- **الأحداث (Events)** - مثل `public event Action<string> TaskUpdated;` لإشعارات التحديث.
- **التفويضات (Delegates) وسلاسل التفويض (Delegate Chains)** - تم إضافة أكثر من `EventHandler` إلى `TaskUpdated`.
- **الاستثناءات (Exceptions)** - مثل `throw new Exception("Task already exists!");`.
- **الحلقات التكرارية (Loops)** - مثل `foreach (var task in tasks)`.
- **الشروط (Conditional Statements)** - مثل `if (tasks.Exists(t => t.Name == taskName))`.
- **الواجهات التفاعلية (Console Input/Output)** - مثل `Console.WriteLine()` و `Console.ReadLine()`.
- **التحكم في البرنامج باستخدام `while (true)`** - لإنشاء قائمة تفاعلية مستمرة.

## 🔗 Future Improvements
- دعم تواريخ انتهاء المهام.
- إمكانية تعيين أولوية لكل مهمة.
- واجهة رسومية باستخدام WPF أو Windows Forms.

---
**🔹 Developed by [Your Name]**

