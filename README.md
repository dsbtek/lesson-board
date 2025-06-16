---

## **Lesson Board App**
An interactive whiteboard application for **teaching, lesson capturing, and PDF exports**.

### **📌 Features**
✅ Real-time whiteboard for teaching  
✅ Text, images, and annotation tools  
✅ Lesson storage and retrieval  
✅ WebAssembly-powered performance boost  
✅ PDF export for reference & review 

## **🖥️ Core Features **
1️⃣ Interactive Whiteboard

Draw, write, and annotate freely.

Supports pen, eraser, and shape tools.

Undo & redo actions for smooth corrections.

2️⃣ Lesson Capture & Storage

Automatically save lesson content.

Store lessons in a structured database.

Retrieve past lessons for review anytime.

3️⃣ PDF Export for Reference

Convert whiteboard content into a downloadable PDF.

Embed images, diagrams, and explanations in the PDF.

Customizable layouts and formatting options.

4️⃣ Real-Time Collaboration

Tutors and students can interact live.

Multi-user access for group learning.

Chat functionality for discussion.

5️⃣ Multimedia Support

Upload images and videos into lessons.

Integrate external resources for enriched learning.

Audio recording for explanations.

6️⃣ Offline Lesson Access

Save lessons locally for review.

Export and share offline materials.

No need for continuous internet access.

7️⃣ User Authentication & Roles

Secure logins for tutors and students.

Role-based access (admin, tutor, student).

Progress tracking for students.

8️⃣ WebAssembly Optimization

Fast rendering of complex lesson content.

Improved performance for real-time updates.

Efficient PDF processing and export.

---
---
##**🚀 Future Enhancements**
✔ AI-powered content suggestions ✔ Voice-to-text automatic transcription ✔ Handwriting recognition for seamless note-taking ✔ Mobile app version for learning on the go

### **🚀 Getting Started**
#### **Prerequisites**
-  
- MongoDB (for lesson storage)  
- Emscripten (for WebAssembly)  
- A modern web browser (Chrome, Firefox)
---
#### **Installation**
Clone the repository:
```sh
git clone https://github.com/yourusername/lesson-board-app.git
cd lesson-board-app
```
Install dependencies:
```sh
npm install
```

#### **Run Backend**
```sh
cd backend
node server.js
```

#### **Run Frontend**
```sh

```

#### **Compile WebAssembly**
```sh
cd wasm
sh compile.sh
```

---

### **📦 Folder Structure**
```
lesson-board-app/
│── backend/         # Server-side logic (Node.js, Express)
│── frontend/        # UI Layer (React.js, Konva.js)
│── wasm/            # WebAssembly modules (C++)
│── database/        # MongoDB configuration
│── public/          # Static files (index.html)
│── README.md        # Project documentation
```

---

### **🔗 API Routes**
#### **Lesson API**
| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/lessons` | Get all lessons |
| `POST` | `/api/lessons` | Create a lesson |
| `GET` | `/api/lessons/:id` | Get lesson by ID |
| `DELETE` | `/api/lessons/:id` | Delete lesson |

#### **Whiteboard API**
| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/board/save` | Save board content |
| `GET` | `/api/board/export` | Export board to PDF |

---

### **📜 License**
This project is open-source under the **MIT License**.

---

