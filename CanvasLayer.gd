extends CanvasLayer


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _on_button_pressed():
	print("PENIS")
	$HTTPRequest.request("http://www.mocky.io/v2/5185415ba171ea3a00704eed")	

func _on_http_request_request_completed(result, response_code, headers, body):
	var json = JSON.new()
	var json_string = json.parse(body.get_string_from_utf8())
	print(typeof(json_string))

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass




