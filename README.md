# DiscoverAPI

Eine kleine .NET 9.0 Web API, die mit Basic Authentication abgesichert ist und zwei URLs (Backend & Identity) aus der Konfiguration zurückliefert.

## Docker build und run

**1. Image bauen**
```bash
docker build -t discoverapi .
```

**2. Container starten**
```bash
docker run -p 8080:8080 discoverapi
```

**Die API läuft danach unter:**
```bash
http://localhost:8080/discoverapi
```

**Authentifizierung:**
```bash
Auth Type: Basic Auth
Username: IDM
Password: 123
```

**Response:**
```bash
{
  "backendUrl": "https://example-backend.com",
  "identityUrl": "https://example-identity.com"
}
```