import cv2
import sys
import numpy as np

image_path = 'E:\\4 Carrera\\TFG\\LOST_TIME_MEMORY\\TFG_Lost_Time_Memory\\TFG_Lost_Time_Memory\\Assets\\Images\\InGameImages\\'
mask_path = 'Masks\\'

# Cargar la imagen original y la máscara binaria
imagen_original = cv2.imread(image_path+sys.argv[2])  # Reemplaza con la ruta de tu imagen original
mascara_binaria = cv2.imread(mask_path+sys.argv[1], cv2.IMREAD_GRAYSCALE)  # Reemplaza con la ruta de tu máscara binaria

# Asegurar que las dimensiones coincidan
if imagen_original.shape[:2] != mascara_binaria.shape:
    mascara_binaria = cv2.resize(mascara_binaria, (imagen_original.shape[1], imagen_original.shape[0]))

imagen_sin_fondo = cv2.bitwise_and(imagen_original, imagen_original, mask=mascara_binaria)

# Convertir la imagen original a formato BGRA (añadir canal alfa)
imagen_original_con_alfa = cv2.cvtColor(imagen_original, cv2.COLOR_BGR2BGRA)

# Establecer el canal alfa según la máscara binaria invertida
imagen_original_con_alfa[:, :, 3] = mascara_binaria

## Guardar la imagen resultante
cv2.imwrite(image_path+'result_'+sys.argv[2], imagen_original_con_alfa)