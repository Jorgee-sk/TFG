import os
import cv2
import sys
import numpy as np

mask_path = 'Masks\\'

# Obtener la ruta del directorio donde se encuentra este script
current_script_path = os.path.dirname(os.path.abspath(__file__))

# Construir la ruta relativa a los directorios de imágenes
relative_path_to_images = os.path.join(current_script_path, '..', 'Assets', 'Images', 'InGameImages\\')
relative_path_to_result = os.path.join(current_script_path, '..', 'Assets', 'Images', 'ResultImages\\')

# Normalizar la ruta
target_image_path = os.path.normpath(relative_path_to_images+sys.argv[2])
target_result_path = os.path.normpath(relative_path_to_result+'result_'+sys.argv[2])

# Cargar la imagen original y la máscara binaria
imagen_original = cv2.imread(target_image_path)  # Reemplaza con la ruta de tu imagen original
mascara_binaria = cv2.imread(mask_path+sys.argv[1], cv2.IMREAD_GRAYSCALE)  # Reemplaza con la ruta de tu máscara binaria

print(f'Ruta al directorio de imágenes: {target_image_path}')
print(f'Ruta al directorio de masks: {mask_path+sys.argv[1]}')
print(f'Ruta al directorio de resultados: {target_result_path}')

# Asegurar que las dimensiones coincidan
if imagen_original.shape[:2] != mascara_binaria.shape:
    mascara_binaria = cv2.resize(mascara_binaria, (imagen_original.shape[1], imagen_original.shape[0]))

imagen_sin_fondo = cv2.bitwise_and(imagen_original, imagen_original, mask=mascara_binaria)

# Convertir la imagen original a formato BGRA (añadir canal alfa)
imagen_original_con_alfa = cv2.cvtColor(imagen_original, cv2.COLOR_BGR2BGRA)

# Establecer el canal alfa según la máscara binaria invertida
imagen_original_con_alfa[:, :, 3] = mascara_binaria

## Guardar la imagen resultante
cv2.imwrite(target_result_path, imagen_original_con_alfa)