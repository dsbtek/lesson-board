---

## **Lesson Board App**
An interactive whiteboard application for **teaching, lesson capturing, and PDF exports**.

### **📌 Features**
✅ Real-time whiteboard for teaching  
✅ Text, images, and annotation tools  
✅ Lesson storage and retrieval  
✅ WebAssembly-powered performance boost  
✅ PDF export for reference & review  

---

### **🚀 Getting Started**
#### **Prerequisites**
- Node.js & npm  
- MongoDB (for lesson storage)  
- Emscripten (for WebAssembly)  
- A modern web browser (Chrome, Firefox)

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
cd frontend
npm start
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

