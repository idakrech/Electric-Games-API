
# Electric Games API

This API provides data about games, characters, and image uploads.

## API Endpoints

### Game
- `GET {{BASE_URL}}/Game` - Get all games
- `GET {{BASE_URL}}/Game/{id}` - Get a game by ID
- `GET {{BASE_URL}}/Game/GetGameByTitle/{title}` - Get a game by title

**Object:**
```json
{
  "id": 0,
  "title": "string",
  "platform": "string",
  "releaseYear": 0,
  "image": "string"
}
```

### Character
- `GET {{BASE_URL}}/Character` - Get all characters
- `GET {{BASE_URL}}/Character/{id}` - Get a character by ID
- `GET {{BASE_URL}}/Character/GetCharacterByName/{name}` - Get a character by name

**Object:**
```json
{
  "id": 0,
  "name": "string",
  "game": "string",
  "image": "string"
}
```

### Image Upload
- `POST {{BASE_URL}}/ImageUpload` - Upload an image

## Environment Setup

Replace `{{BASE_URL}}` with the appropriate base URL for your environment:

- **For Local Development:**
  - Set `{{BASE_URL}}` to `https://localhost:7265` (or your local host URL if different).

- **For Live Deployment:**
  - Set `{{BASE_URL}}` to `https://electric-games-api-production.up.railway.app` for the live version.

## Example

To call the `GET` endpoint for games, use:

- Local Development: `https://localhost:7265/Game`
- Live Deployment: `https://electric-games-api-production.up.railway.app/Game`

## How to Run Locally

1. Clone this repository to your local machine.
2. Install the necessary packages and dependencies using:
   ```bash
   dotnet restore
   ```
3. Run the project locally using:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:7265` by default.

4. To test the endpoints locally, use your browser or Postman with the `localhost` URL.

## Deployment to Railway

The API is also deployed on Railway. You can access the live instance at:

- **Live URL:** [Electric Games API - Live](https://electric-games-api-production.up.railway.app)

For more information on setting up the Railway project, check the [Railway documentation](https://railway.app/docs).
