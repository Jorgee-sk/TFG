import sys

def ejecutar_script(script_path, image_path):
    exec(open(script_path).read(), {'image_path': image_path, 'image_name': sys.argv[2]})

try:
    script_path = sys.argv[1]
    image_path = 'E:\\4 Carrera\\TFG\\LOST_TIME_MEMORY\\TFG_Lost_Time_Memory\\TFG_Lost_Time_Memory\\Assets\\Images\\InGameImages\\' + sys.argv[2]

    ejecutar_script(script_path, image_path)

except Exception as e:
    print(f"Error: {e}")