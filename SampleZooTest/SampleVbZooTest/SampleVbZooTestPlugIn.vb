Imports System
Imports System.Collections.Generic
Imports Rhino.PlugIns

Namespace SampleVbZooTest

  '''<summary>
  ''' SampleVbZooTestPlugIn plug-in
  '''</summary>
  Public Class SampleVbZooTestPlugIn
    Inherits PlugIn

    Shared _instance As SampleVbZooTestPlugIn

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
      ' Rhino only creates one instance of a plug-in, 
      ' so it is safe to store a reference in a shared property.
      _instance = Me
    End Sub

    ''' <summary>
    ''' Gets the one and only instance of this plug-in.
    ''' </summary>
    Public Shared ReadOnly Property Instance() As SampleVbZooTestPlugIn
      Get
        Return _instance
      End Get
    End Property

    '''<summary>
    ''' PlugIn.OnLoad override
    '''</summary>
    Protected Overrides Function OnLoad(ByRef errorMessage As String) As LoadReturnCode
      ' Ask Rhino to get a product license for us.
      Dim validator As New ValidateProductKeyDelegate(AddressOf ValidateProductKey)
      Dim rc As Boolean = GetLicense(LicenseBuildType.Release, validator)
      If Not rc Then
        Return LoadReturnCode.ErrorNoDialog
      End If

      Return LoadReturnCode.Success
    End Function

    ''' <summary>
    ''' Create a method with the same signature as the 
    ''' ValidateProductKeyDelegate delegate.
    ''' </summary>
    Private Shared Function ValidateProductKey(productKey As String, ByRef licenseData As Rhino.PlugIns.LicenseData) As ValidateResult

      ' This class contains information about your product's license.
      licenseData = New LicenseData()

      ' If this example, we won't do much valiation...
      If String.IsNullOrEmpty(productKey) Then
        Return ValidateResult.ErrorShowMessage
      End If

      ' This value will never be display in any user interface.
      ' When your plugin's ValidateProductKey member is called, it is
      ' passed a a product, or CD, key that was entered into the Zoo
      ' administrator console. Your ValidateProductKey will validate
      ' the product key and decode it into a product license. This is
      ' where you can store this license. This value will be passed
      ' to your application at runtime when it requests a license.
      licenseData.ProductLicense = productKey

      ' This value will display in user interface items, such as in
      ' the Zoo console and in About dialog boxes. Also, this value
      ' is used to uniquely identify this license. Thus, it is
      ' critical that this value be unique per product key, entered
      ' by the administrator. No other license of this product, as
      ' valided by this plugin, should return this value.
      '
      ' This example just scrambles the productKey...
      licenseData.SerialNumber = Scramble(productKey)

      ' This value will display in user interface items, such as in
      ' the Zoo console and in About dialog boxes.
      ' (e.g. "Rhinoceros 5.0", "Rhinoceros 5.0 Commercial", etc.)
      licenseData.LicenseTitle = "SampleVbZooTest 1.0 Commercial"

      ' The build of the product that this license work with.
      ' When your product requests a license from the Zoo, it
      ' will specify one of these build types.
      licenseData.BuildType = LicenseBuildType.Release

      ' Zoo licenses can be used by more than one instance of any application.
      ' For example, a single Rhion Education Lab license can be used by up
      ' to 30 systems simulaneously. If your license supports multiple instance,
      ' then specify the number of supported instances here. Otherwise just
      ' specify a value of 1 for single instance use.
      licenseData.LicenseCount = 1

      ' The Zoo supports licenses that expire. If your licensing scheme
      ' is sophisticated enough to support this, then specify the
      ' expiration date here. Note, this value must be speicified in
      ' Coordinated Universal Time (UTC). If your license does not expire,
      ' then just this value to null.
      licenseData.DateToExpire = Nothing

      ' This icon will displayed in the "Licenses" page in the Options dialog.
      ' Note, this can be null. Also note, LicenseData creates it's own copy
      ' of the icon.
      licenseData.ProductIcon = My.Resources.Main

      Return ValidateResult.Success
    End Function

    ''' <summary>
    ''' Randomizes character positions in string
    ''' </summary>
    Private Shared Function Scramble(input As String) As String

      If String.IsNullOrEmpty(input) Then
        Return input
      End If

      Dim inputChars As New List(Of Char)(input)
      Dim outputChars As Char() = New Char(inputChars.Count - 1) {}
      Dim rand As New Random()

      For i As Integer = inputChars.Count - 1 To 0 Step -1
        Dim index As Integer = rand.[Next](i)
        outputChars(i) = inputChars(index)
        inputChars.RemoveAt(index)
      Next

      Return New String(outputChars)
    End Function

  End Class

End Namespace