
# ToDo Fullstack Project 📝

A comprehensive full-stack task management application built with the **MERN** stack (MongoDB, Express, React, Node.js). This project demonstrates a complete flow of data from a dynamic user interface to a persistent database through a RESTful API.

---

## 🚀 Features

* **Full CRUD Operations:** Create, Read, Update, and Delete tasks seamlessly.
* **Real-time Updates:** React-based UI that reflects changes instantly.
* **Persistent Storage:** Data is stored in a MongoDB database, ensuring tasks are saved between sessions.
* **Responsive Design:** Optimized for various screen sizes.
* **Clean Architecture:** Separated concerns between Frontend, Backend, and Database models.

---

## 🛠️ Tech Stack

### Frontend
* **React.js:** Component-based UI library.
* **CSS3:** Modern styling for a clean user experience.
* **Axios/Fetch:** For asynchronous API communication.

### Backend
* **Node.js:** JavaScript runtime environment.
* **Express.js:** Web framework for building the REST API.
* **Mongoose:** ODM (Object Data Modeling) for MongoDB.

### Database
* **MongoDB:** NoSQL database for flexible and scalable data storage.

---

## 🏗️ Architecture

The project follows a classic Client-Server-Database architecture:



1.  **Client (React):** Handles user interactions and state management.
2.  **Server (Node/Express):** Validates requests and processes business logic.
3.  **Database (MongoDB):** Stores task objects with a defined schema (Title, Description, Status).

---

## 💻 Getting Started

### Prerequisites
* Node.js installed
* MongoDB instance (Local or Atlas)

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yael3222664-alt/ToDoFullstackProject.git](https://github.com/yael3222664-alt/ToDoFullstackProject.git)
    ```

2.  **Setup Backend:**
    ```bash
    cd server
    npm install
    npm start
    ```

3.  **Setup Frontend:**
    ```bash
    cd client
    npm install
    npm start
    ```

---

## 📈 Future Improvements
* [ ] User Authentication (JWT).
* [ ] Task Categories/Tags.
* [ ] Due date reminders and notifications.
* [ ] Dark Mode support.

---

## 👤 Author
**Yael** - [GitHub Profile](https://github.com/yael3222664-alt)
