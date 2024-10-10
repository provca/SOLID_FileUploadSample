# Multiplatform File Upload Project
This project is a comprehensive solution that enables file management and uploads across multiple platforms and technologies. Additionally, the developed architecture follows the principles of SOLID methodologies, ensuring cleaner, maintainable, and scalable code. Its implementation facilitates the separation of responsibilities, improves cohesion among components, and promotes better understanding of the code by developers.
## Project Architecture
### Backend
- **LibFilesManager:** This module handles the logic of file management, allowing efficient manipulation of files across various operations. Its modular design facilitates scalability and maintenance. It includes basic file validation measures, such as size and format. Moreover, only files with formats specified in the Enum can be uploaded.
- **SwitchLoggers:** A robust logging system that provides easy integration and configuration, enhancing debugging and monitoring capabilities. This project can be found at [https://github.com/provca/SwitchLoggers](https://github.com/provca/SwitchLoggers "https://github.com/provca/SwitchLoggers") and has been used exclusively to demonstrate how simple it is to integrate other projects based on SOLID methodologies.

------------

### Middleware
- **API_NetCore:** The central API that connects all components of the system, providing a RESTful interface for interaction with the frontend. It is designed following SOLID principles, ensuring clean and maintainable code. It is used for VSTO and WebAssembly projects, connecting to the methods and factories of LibServices. The API does not contain logic that exclusively depends on the projects, allowing it to serve as a stable and lightweight connector between platforms.
- **LibServices:** A library of services that abstracts business logic, allowing for easy reuse and unit testing. It can be directly used with Blazor Client or Windows Forms projects, among others.

------------
### Frontends
All frontends serve the same functions:
- Select a file.
- Rename the file (optional).
- Select a folder (optional).
- Copy the file to the selected folder.

------------
#### Sample frontends in the repository:
1. **AngularWebApp:** A web application that uses the API_NetCore project to execute backend logic.
2. **ASPNETCore_MVC:** A classic MVC implementation that allows for the development of web applications using Razor for dynamic content generation.
3. **BlazorApp:** Utilizes Blazor technology to create interactive client-side web applications, allowing the use of C# instead of JavaScript.
4. **BlazorWebApp:** Similar to BlazorApp but optimized for web applications. It also uses the API_NetCore project to execute backend logic.
5. **MauiSampleApp:** An example application using .NET MAUI, enabling the creation of multiplatform applications for mobile and desktop devices.
6. **VSTO_ExcelUploadFile:** An Excel add-in that allows users to upload files directly from the Excel interface, improving usability for users working in office environments. It utilizes the API_NetCore project to execute backend logic.
7. **WinFormUploadFile:** A desktop application that provides a simple interface for file uploads, using Windows Forms.

## File Upload Process
The file upload process is managed through an architecture based on factories, models, and endpoints (when using the API), allowing for seamless integration between the frontend and backend:

**Select File:** The user selects a file through the frontend interface, whether in a web application, an Excel add-in, or a desktop application.

**Upload Model:** An upload model (e.g., UploadFileFormModel) is used to encapsulate all the necessary parameters for the upload, ensuring valid and consistent data is sent to the backend.

**Adapters:**
- **IFormFile:** An adapter converts file information (IFormFile) to a specific service that can be utilized by the backend, ensuring separation of concerns and cleaner code.

- **byte[] / IBrowserFile:** For Blazor applications, a byte[] adapter that works with IBrowserFile is also used. This adapter allows files to be managed efficiently and integrated seamlessly, facilitating uploads from Blazor interfaces and Excel add-ins.

**Service Factory:** The factory creates instances of the necessary service to handle the upload logic. This allows the backend to be extended or modified without affecting the frontend logic. The key are the adapters that transform the model into IFileService.

**API Endpoints:** The API endpoints (as defined in API_NetCore) receive upload requests and process the file using the service created by the factory. This includes file validation, error handling, and an appropriate response to the user.

## Collaboration Ease
The modular design of the system and its extensive documentation facilitate collaboration between frontend and backend developers, allowing them to work together or separately:

- **Joint Development:** Teams can clearly define the interfaces and contracts between the frontend and backend, minimizing dependencies and enabling efficient parallel development.
- **Independent Work:** Thanks to the separation of logic into classes, factories, and models, developers can work in their respective areas without interfering with each other's work. For example, frontend developers can implement new user interface features while backend developers work on the file upload logic.
- **Testing Ease:** Unit testing is simplified due to modularity and the use of factories, allowing developers to test their components in isolation.

## Advantages and Strengths
- **Multiplatform:** With the diversity of frontends, this project adapts to different environments and user preferences, from web applications to desktop add-ins, allowing frontend developers to focus solely on their tasks and responsibilities without needing to touch the backend.
- **Modularity:** The clear separation between the backend, middleware, and frontend allows for more efficient development and maintenance, as well as the possibility to scale individual components and/or add new projects that complement the app's functionalities.
- **Simplicity of Integration:** The RESTful API facilitates integration with other systems and services, enabling effective interoperability. Feel free to experiment with this repository and create your own frontend in PHP, React, WPF, Console, etc.
- **Usability:** The UX/UI team can focus on designing interfaces to provide a smooth and functional user experience, while FrontEnd developers can concentrate on clear and precise guidelines.
- **Efficiency:** The backend team can create new functionalities and features without affecting the project, thanks to the separation of responsibilities in SOLID, resulting in stable outcomes and reducing the error rate before deployment.
- **Sustainability:** By following best practices in programming and design, this project is prepared to evolve and adapt to future needs.

> Note: This repository is a simple example of how to apply SOLID principles in our projects and should only be used as a reference and improvement tool.
