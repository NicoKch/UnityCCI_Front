# Unity Mobile App Project - User Statistics and Comments

## Overview
This project is a mobile application developed as part of a Unity training exercise. It consists of:

- **A front-end built in Unity** (using Unity UI Toolkit and C#).
- **A REST API back-end** built with Spring Boot.
- **A MySQL database** for data storage.

The application includes the following features:

1. **Login Scene**: Users can log in with predefined credentials.
2. **Menu Scene**: A navigation menu for accessing different scenes.
3. **Statistics Scene**: Displays user statistics retrieved from the database.
4. **Comments Scene**: Allows users to post comments, which are saved to the database.

## Prerequisites

To run this project, the following tools and dependencies are required:

### Back-End
- **Java JDK 21 or higher**
- **Maven**
- **Spring Boot** (preconfigured in the project)
- **MySQL Server** (version 8.0 or higher)

### Front-End
- **Unity Hub** (latest version)
- **Unity Editor** (2022.3 LTS or compatible version with UI Toolkit support)

### Additional Tools
- **Postman** (optional, for testing the REST API)
- **Android Build Support** (if deploying to an Android device)

## Installation Steps

### Back-End Setup
1. Clone the repository from the provided source.
   ```bash
   git clone https://github.com/NicoKch/UnityCCI_Back.git
   ```
2. Navigate to the back-end directory.
   ```bash
   cd backend
   ```
3. Configure the **application.properties** file in the `src/main/java/com.projetCC/DataBaseService/MySqlConnector` directory with your MySQL connection details:
   ```properties
        "jdbc:mysql://localhost:3306/projetcci_nk" line 26 : change projetcci_nk if you changed the name of the database
        change user and password line 29 with your own database ids (default : username "root" password "root")
   ```
4. Run the application using Maven:
   ```bash
   mvn spring-boot:run
   ```
5. Ensure the API is running by visiting `http://localhost:8080` in your browser or testing with Postman.

### Database Setup
1. Create a MySQL database.
   ```sql
   CREATE DATABASE your_database_name;
   ```
2. Import the required schema and initial data (if provided) using the `schema.sql` or `data.sql` file.

### Unity Front-End Setup
1. Open Unity Hub and click **Open Project**.
2. Navigate to the front-end directory and select it.
3. Install required Unity packages if prompted (e.g., UI Toolkit).
4. Open the **Build Settings** window (File > Build Settings).
5. Ensure **Android Build Support** is installed and configure the target platform as **Android** (or keep it as PC if testing on a desktop).
6. Press **Play** to test the application in the Unity Editor.

### Deployment (Optional)
1. To deploy the application to an Android device:
   - Connect your device via USB.
   - Enable USB debugging on your Android device.
   - Build and Run the project from Unity (File > Build Settings > Build and Run).

## Usage Instructions

### Login Credentials
Use the following credentials to log in:
- **Email**: `mail@test.com`
- **Password**: `azerty`

### Navigation
1. After logging in, you will be directed to the **Menu Scene**.
2. From the menu, you can:
   - **View Statistics**: Access the **Statistics Scene** to see user data.
   - **Post Comments**: Access the **Comments Scene** to submit a comment.

### Features
- **Statistics Scene**: Fetches user statistics from the back-end API and displays them in a visually appealing format.
- **Comments Scene**: Allows users to submit comments. Comments are sent to the back-end API and stored in the MySQL database.

## Troubleshooting

### Common Issues
1. **Back-End Fails to Start**:
   - Verify that the `application.properties` file has the correct database credentials.
   - Ensure MySQL Server is running.

2. **Unity Errors**:
   - Check that all required packages are installed.
   - Ensure the project uses the correct Unity version.

3. **API Connection Errors**:
   - Confirm that the API is running on `http://localhost:8080`.
   - Check your network configuration if running on a different device.

## Project Structure

### Back-End
- **Controller Layer**: Handles incoming API requests (e.g., login, statistics, comments).
- **Service Layer**: Contains business logic.
- **Repository Layer**: Manages database access.

### Front-End
- **Scenes**:
  - **LoginScene**: Login interface.
  - **MenuScene**: Navigation menu.
  - **StatsScene**: Displays user statistics.
  - **CommentsScene**: Enables posting comments.
- **Scripts**:
  - `ApiService`: Manages API requests.
  - `PlayerStatsManager`: Handles user statistics logic.
  - `CommentManager`: Manages comment submissions.

## Contact
For any questions or issues, feel free to reach out to the project instructor or refer to the course materials.

