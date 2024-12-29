extends Node

func _ready():
	$HTTPRequest.request_completed.connect(_on_request_completed)
	$HTTPRequest.request("http://ip-api.com/json/")

func _on_request_completed(result, response_code, headers, body):
	var json = JSON.parse_string(body.get_string_from_utf8())
	var lat = json["lat"]
	var lon = json["lon"]
	
	print(lat, " ", lon)
