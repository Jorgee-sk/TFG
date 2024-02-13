using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GenerateMask : MonoBehaviour
{
    public ListImages listImages;
    public Button generateMaskBtn;
    private string _currentImageName;

    void OnEnable()
    {
        generateMaskBtn.onClick.AddListener(() => GenerateBinaryMask());
        generateMaskBtn.onClick.AddListener(() => ApplyMask());
    }

    void ApplyMask()
    {
        print("Holaaaaa");
    }
    
    void GenerateBinaryMask()
    {
        _currentImageName = listImages.GetCurrentImageName();
        
        try
        {
            /* Comando que deseamos ejecutar en el cmd -> será el nombre del script de python ya que con la /k
             accedemos al directorio */
            string command = "cd python && venvActivation.py generateBinaryMask.py "+_currentImageName;

            // Configurar el proceso de inicio
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/k {command}");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            // Iniciar el proceso
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                // Leer la salida estándar y de error del proceso
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Esperar a que el proceso termine
                process.WaitForExit();

                // Imprimir la salida en Unity
                Debug.Log("Salida estándar: " + output);

                // Imprimir errores en Unity (si los hay) este codigo se va a quitar jeje
                if (!string.IsNullOrEmpty(error))
                {
                    Debug.LogError("Error durante la ejecución del comando: " + error);
                }

                // Imprimir el código de salida en Unity
                Debug.Log($"Código de salida: {process.ExitCode}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al ejecutar el comando: " + ex.Message);
        }
    }
}