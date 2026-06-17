Imports ConteoMVC.Models

Public Class JuegoController

    Private niveles As New List(Of Nivel)
    Private indiceActual As Integer = 0

    Public Sub New()

        niveles.Add(New Nivel With {
            .NumeroNivel = 1,
            .Imagen = "manzanas.png",
            .CantidadCorrecta = 5
        })

        niveles.Add(New Nivel With {
            .NumeroNivel = 2,
            .Imagen = "peras.png",
            .CantidadCorrecta = 4
        })

        niveles.Add(New Nivel With {
            .NumeroNivel = 3,
            .Imagen = "naranjas.png",
            .CantidadCorrecta = 6
        })

    End Sub

    Public Function ObtenerNivel() As Nivel
        Return niveles(indiceActual)
    End Function

    Public Function Verificar(respuesta As Integer) As Boolean

        Return respuesta = niveles(indiceActual).CantidadCorrecta

    End Function

    Public Sub SiguienteNivel()

        If indiceActual < niveles.Count - 1 Then
            indiceActual += 1
        End If

    End Sub

End Class