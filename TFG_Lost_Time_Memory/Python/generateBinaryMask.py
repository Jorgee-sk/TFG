import cv2
import numpy as np
from tensorflow import keras
from keras.models import load_model

def cargarModelo(ruta_modelo):
    # Cargar el modelo previamente entrenado
    modelo = load_model(ruta_modelo)
    return modelo

def preprocessing(imagen_path, target_size=(256, 256)):
    # Leer y preprocesar la imagen
    img = cv2.imread(imagen_path)
    img = cv2.resize(img, target_size)
    img = img / 255.0  # Normalizar píxeles en el rango [0, 1]
    img = np.expand_dims(img, axis=0)  # Agregar dimensión del lote
    return img

def applyModelToImage(modelo, imagen_preprocesada):
    # Aplicar el modelo para obtener la máscara segmentada
    mascara = modelo.predict(imagen_preprocesada)
    return mascara

def postProcessingMask(mascara):
    # Puedes realizar cualquier postprocesamiento necesario aquí
    # Por ejemplo, umbralizar la máscara
    mascara_binaria = (mascara > 0.5).astype(np.uint8)
    return mascara_binaria

def saveResult(imagen_original, mascara_binaria, resultado_path):
    # Asegurar que las dimensiones coincidan
    if imagen_original.shape[:2] != mascara_binaria.shape[1:3]:
        mascara_binaria = cv2.resize(mascara_binaria[0], (imagen_original.shape[1], imagen_original.shape[0]))

    #Los parámetros son: Alpha , beta y gamma, el parámetro alpha me oculta todos los colores, beta hace que se vea mas o menos el 
    # blanco y gamma no se hahaha
    # Superponer la máscara en la imagen original
    resultado = cv2.addWeighted(imagen_original, 0, cv2.cvtColor(mascara_binaria * 255, cv2.COLOR_GRAY2BGR), 1, 0.5)
    # Guardar el resultado en el mismo directorio que el script
    cv2.imwrite(resultado_path, resultado)

# Ruta del modelo entrenado
ruta_modelo_entrenado = 'unetModel.h5'

# Cargar el modelo
modelo = cargarModelo(ruta_modelo_entrenado)

# Ruta de la imagen que deseas segmentar
ruta_imagen_a_segmentar = locals()['image_path']

# Preprocesar la imagen
imagen_preprocesada = preprocessing(ruta_imagen_a_segmentar)

# Segmentar la imagen
mascara = applyModelToImage(modelo, imagen_preprocesada)

# Postprocesar la máscara si es necesario
mascara_binaria = postProcessingMask(mascara)

# Visualizar los resultados
imagen_original = cv2.imread(ruta_imagen_a_segmentar)

# Guardar el resultado en el directiorio de máscaras con el prefijo mask
resultado_path = 'Masks\\mask'+locals()['image_name']+'.jpg'
saveResult(imagen_original, mascara_binaria, resultado_path)
