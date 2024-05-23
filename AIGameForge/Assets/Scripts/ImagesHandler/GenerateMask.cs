using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GenerateMask : MonoBehaviour
{
    public ListImages listImages;
    public Button generateMaskBtn;
    private string _currentImageName;
    private string _currentMaskImageName;

    void OnEnable()
    {
        generateMaskBtn.onClick.AddListener(() => GenerateBinaryMask());
        generateMaskBtn.onClick.AddListener(() => ApplyMask());
    }

    void GenerateBinaryMask()
    {
        _currentImageName = listImages.GetCurrentImageName();
        if (File.Exists(Directory.GetCurrentDirectory() + "\\Python\\Masks\\mask" + _currentImageName))
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\Python\\Masks\\mask" + _currentImageName);
        }
        
        try
        {
            /* Comando que deseamos ejecutar en el cmd -> será el nombre del script de python ya que con la /k
             accedemos al directorio */
            string command = "cd python && venvActivation.py generateBinaryMask.py " + _currentImageName;
            
            // Configurar el proceso de inicio
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {command}");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true; // Ocultar la ventana del cmd
            startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Ejecutar en segundo plano

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
                //Debug.Log("Salida estándar: " + output);

                // Imprimir errores en Unity (si los hay) este codigo se va a quitar jeje
                //if (!string.IsNullOrEmpty(error))
                //{
                //    Debug.LogError("Error durante la ejecución del comando: " + error);
                //}

                // Imprimir el código de salida en Unity
                //Debug.Log($"Código de salida: {process.ExitCode}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al ejecutar el comando: " + ex.Message);
        }
    }

    void ApplyMask()
    {
        _currentMaskImageName = listImages.GetCurrentMaskImageName();

        try
        {
            /* Comando que deseamos ejecutar en el cmd -> será el nombre del script de python ya que con la /k
             accedemos al directorio */
            string command = "cd python && applyMask.py " + _currentMaskImageName + " " + _currentImageName;

            // Configurar el proceso de inicio
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {command}");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true; // Ocultar la ventana del cmd
            startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Ejecutar en segundo plano

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
                //Debug.Log("Salida estándar: " + output);

                // Imprimir errores en Unity (si los hay) este codigo se va a quitar jeje
                //if (!string.IsNullOrEmpty(error))
                //{
                //    Debug.LogError("Error durante la ejecución del comando: " + error);
                //}

                // Imprimir el código de salida en Unity
                //Debug.Log($"Código de salida: {process.ExitCode}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error al ejecutar el comando: " + ex.Message);
        }

        SceneManager.LoadScene(2);
    }
}