import os
import sys

def ejecutar_script(script_path, image_path):
    exec(open(script_path).read(), {'image_path': image_path, 'image_name': sys.argv[2]})

try:
    script_path = sys.argv[1]
    # Obtener la ruta del directorio donde se encuentra este script
    current_script_path = os.path.dirname(os.path.abspath(__file__))

    # Construir la ruta relativa a los directorios de imágenes
    relative_path_to_images = os.path.join(current_script_path, '..', 'Assets', 'Images', 'InGameImages\\')
    #Normalizamos la ruta
    image_path = os.path.normpath(relative_path_to_images + sys.argv[2])

    ejecutar_script(script_path, image_path)

except Exception as e:
    print(f"Error: {e}")