Imports Rhino
Imports Rhino.Commands

Namespace SampleVbZooTest

  ''' <summary>
  ''' SampleVbZooTestCommand command
  ''' </summary>
  <System.Runtime.InteropServices.Guid("ef155bf5-c977-4fe9-b659-f30db9c1d2b4")> _
  Public Class SampleVbZooTestCommand
    Inherits Command

    Shared _instance As SampleVbZooTestCommand

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
      ' Rhino only creates one instance of each command class defined in a
      ' plug-in, so it is safe to store a reference in a shared field.
      _instance = Me
    End Sub

    '''<summary> 
    ''' Gets the one and only instance of this command.
    ''' </summary>
    Public Shared ReadOnly Property Instance() As SampleVbZooTestCommand
      Get
        Return _instance
      End Get
    End Property

    ''' <summary>
    ''' Gets the command name as it appears on the Rhino command line.
    ''' </summary>
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbZooTest"
      End Get
    End Property

    ''' <summary>
    ''' Called by Rhino to run this command.
    ''' </summary>
    Protected Overrides Function RunCommand(ByVal doc As RhinoDoc, ByVal mode As RunMode) As Result
      RhinoApp.WriteLine("The {0} command is under construction", EnglishName)
      Return Result.Success
    End Function

  End Class

End Namespace