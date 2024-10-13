# Blog API

## Description
A simple Blog API built with ASP.NET Core that allows users to manage blog posts and comments. The API supports user registration, login, and CRUD operations for blog posts and comments.

## Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/karakaptan7/blog-api.git
    ```
2. Navigate to the project directory:
    ```sh
    cd blog-api
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```
4. Update the database:
    ```sh
    dotnet ef database update
    ```
5. Run the application:
    ```sh
    dotnet run
    ```

## Usage
The API can be accessed at `http://localhost:5176`.

### API Endpoints

#### User
- **Register**: `POST /api/user/register`
- **Login**: `POST /api/user/login`

#### Blog Posts
- **Get All Posts**: `GET /api/blog/getall`
- **Get Post by ID**: `GET /api/blog/getbyid/{id}`
- **Create Post**: `POST /api/blog/create`
- **Delete Post**: `DELETE /api/blog/delete/{id}`

#### Comments
- **Get All Comments**: `GET /api/comment/getall`
- **Get Comments by Post ID**: `GET /api/comment/getbypostid/{blogPostId}`
- **Get Comment by ID**: `GET /api/comment/getbyid/{id}`
- **Create Comment**: `POST /api/comment/create`
- **Delete Comment**: `DELETE /api/comment/delete/{id}`

## License
This project is licensed under the MIT License.
