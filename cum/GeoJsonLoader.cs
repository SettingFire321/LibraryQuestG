using Godot;
using System;
using System.Text.Json;

public partial class GeoJsonLoader : Node {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		string filePath = "res://cum/SanFrancisco.geojson";
        string geoJsonData = LoadGeoJson(filePath);
        ParseGeoJson(geoJsonData);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {



	}

	private string LoadGeoJson(string filePath) {

        using (FileAccess file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read)) {
            return file.GetAsText();
        }

    }

	private void ParseGeoJson(string geoJsonData) {

        JsonDocument doc = JsonDocument.Parse(geoJsonData);
        JsonElement root = doc.RootElement;
        if (root.TryGetProperty("features", out JsonElement features)) {
            foreach (JsonElement feature in features.EnumerateArray()) {
                if (feature.TryGetProperty("geometry", out JsonElement geometry)) {
                    string type = geometry.GetProperty("type").GetString();
                    JsonElement coordinates = geometry.GetProperty("coordinates");
                    switch (type) {
                        case "Point":
                            DrawPoint(coordinates);
                            break;
                        case "LineString":
                            DrawLineString(coordinates);
                            break;
                        case "Polygon":
                            DrawPolygon(coordinates);
                            break;
                    }
                }
            }
        }

    }

	private void DrawPoint(JsonElement coordinates) {

        // Extract coordinates
        float x = (float) coordinates[0].GetDouble();
        float y = (float) coordinates[1].GetDouble();
        // Create a visual representation
        var point = new Sprite2D();
        point.Texture = GD.Load<Texture2D>("res://cum/Placeholder.jpg");
        point.Position = new Vector2(x, y);
        AddChild(point);

    }

    private void DrawLineString(JsonElement coordinates) {

        var line = new Line2D();
        foreach (JsonElement coord in coordinates.EnumerateArray()) {
            float x = (float)coord[0].GetDouble();
            float y = (float)coord[1].GetDouble();
            line.AddPoint(new Vector2(x * -1, y * -1));
        }
        line.Width = (float) 0.0002;
        line.DefaultColor = Colors.Red;
        AddChild(line);

    }

    private void DrawPolygon(JsonElement coordinates) {

        var polygon = new Polygon2D();
        var points = new Vector2[coordinates[0].GetArrayLength()];
        int index = 0;
        foreach (JsonElement coord in coordinates[0].EnumerateArray()) {
            float x = (float)coord[0].GetDouble();
            float y = (float)coord[1].GetDouble();
            points[index++] = new Vector2(x, y);
        }
        polygon.Polygon = points;
        polygon.Color = new Color(0.5f, 0.8f, 0.2f, 0.5f);
        AddChild(polygon);
		
    }

}
