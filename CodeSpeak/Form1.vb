﻿Imports System.Text.RegularExpressions

Public Class Form1

    Private Shared Function Cipher(input As String, oldAlphabet As String, newAlphabet As String, ByRef output As String) As Boolean
        output = String.Empty

        If oldAlphabet.Length <> newAlphabet.Length Then
            Return False
        End If

        For i As Integer = 0 To input.Length - 1
            Dim oldCharIndex As Integer = oldAlphabet.IndexOf(Char.ToLower(input(i)))

            If oldCharIndex >= 0 Then
                output += If(Char.IsUpper(input(i)), Char.ToUpper(newAlphabet(oldCharIndex)), newAlphabet(oldCharIndex))
            Else
                output += input(i)
            End If
        Next

        Return True
    End Function

    Public Shared Function Encipher(input As String, cipherAlphabet As String, ByRef output As String) As Boolean
        Dim plainAlphabet As String = "aàbdeèégiìmnoòprs"
        Return Cipher(input, plainAlphabet, cipherAlphabet, output)
    End Function

    Public Shared Function CustomEncipher(input As String, customPlain As String, cipherAlphabet As String, ByRef output As String) As Boolean

        Return Cipher(input, customPlain, cipherAlphabet, output)
    End Function




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        EncryptedOutput.Clear()
        NormalInput.Clear()
        CustomCipherInput.Clear()
        CustomPlainInput.Clear()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim text As String = NormalInput.Text 'gets the input from the text box aàbdeèégiìmnoòprs
        Dim cipherAlphabet As String = "oòpgiìídeènmaàbsr" 'sets the cipherAlphabet according to the plain alphabet combinations
        Dim cipherText As String = "" 'creates a variable that will contain the encrypted text
        Encipher(text, cipherAlphabet, cipherText) 'encrypts the text
        EncryptedOutput.Text = cipherText 'gives you the encrypted text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EncryptedOutput.Text = NormalInput.Text.Replace("a", "afa").Replace("e", "efe").Replace("i", "ifi").Replace("o", "ofo").Replace("u", "ufu").Replace("à", "afà").Replace("è", "efè").Replace("é", "efé").Replace("ì", "ifì").Replace("ò", "ofò").Replace("ù", "ufù").Replace("A", "AFA").Replace("E", "EFE").Replace("I", "IFI").Replace("O", "OFO").Replace("U", "UFU").Replace("À", "AFÀ").Replace("È", "EFÈ").Replace("É", "EFÉ").Replace("Ì", "IFÌ").Replace("Ò", "OFÒ").Replace("Ù", "UFÙ")
            ' Capitalizzazione del testo
    Dim capitalizedText As String = ""
Dim words As String() = text.Split(" ")
For i As Integer = 0 To words.Length - 1
    Dim word As String = words(i)
    Dim isFirstWord As Boolean = (i = 0)
    Dim isCapitalized As Boolean = False

    If word.StartsWith(".") Then
        ' La parola è preceduta da un punto, quindi la prima lettera deve essere capitalizzata come Ifi
        capitalizedText += ". " + Char.ToUpper(word(1)) + word.Substring(2).ToLower()
        isCapitalized = True
    Else
        ' La parola non è preceduta da un punto, quindi la prima lettera deve essere capitalizzata completamente in maiuscolo
        capitalizedText += " " + word.ToUpper()
        isCapitalized = True
    End If

    ' Se la parola non è la prima e non inizia con un punto, allora la prima lettera deve essere capitalizzata solo se la parola precedente termina con un punto.
    If Not isFirstWord And Not isCapitalized Then
        Dim previousWord As String = words(i - 1)
        If previousWord.EndsWith(".") Then
            capitalizedText += " " + Char.ToUpper(word(0)) + word.Substring(1).ToLower()
        Else
            capitalizedText += " " + word.ToLower()
        End If
    End If
Next

    Next

    ' Rimozione del primo spazio se presente
    If capitalizedText.Length > 0 AndAlso capitalizedText(0) = " " Then
        capitalizedText = capitalizedText.Substring(1)
    End If

    EncryptedOutput.Text = capitalizedText

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim text As String = NormalInput.Text 'gets the input from the text box
        Dim CustomPlainAlphabet As String = CustomPlainInput.Text
        Dim cipherAlphabet As String = CustomCipherInput.Text 'sets the cipherAlphabet according to the plain alphabet combinations
        Dim cipherText As String = "" 'creates a variable that will contain the encrypted text
        Dim unused = CustomEncipher(text, CustomPlainAlphabet, cipherAlphabet, cipherText) 'encrypts the text
        EncryptedOutput.Text = cipherText 'gives you the encrypted text
    End Sub

    Private Sub ITALIAN_Click(sender As Object, e As EventArgs) Handles ITALIAN.Click
        Button1.Text = "Converti con cifrario standard"
        Button4.Text = "Converti con cifrario personalizzato"
        Button2.Text = "Converti in alfabeto farfallino"
        Button3.Text = "Svuota"
        Button5.Text = "Esci"
        GroupBox1.Text = "Testo normale da crittografare"
        Label1.Text = "Puoi scegliere se criptare/decriptare un messaggio usando il cifrario standard o creandone uno personalizzato. Nella prima casella di testo inserisci senza spazi le lettere o simboli che desideri siano sostituiti. Nella casella sottostante scrivi i corrispettivi simboli che cambieranno, senza spazi"
        CustomPlainInput.PlaceholderText = "Alfabeto custom di partenza"
        CustomCipherInput.PlaceholderText = "Conversione custom"
    End Sub

    Private Sub English_Click(sender As Object, e As EventArgs) Handles English.Click
        Button1.Text = "Convert with Default Substitution Cipher"
        Button4.Text = "Convert with Custom Substitution Cipher"
        Button2.Text = "Convert to Farfallino"
        Button3.Text = "Clear"
        Button5.Text = "Exit"
        GroupBox1.Text = "Normal text to be encrypted"
        Label1.Text = "Choose between the standard cipher method or a custom one. In the first textbox you'll have to list the letters that will be replaced. In the textbox below, you'll write the corresponding letter or symbol you want to use to replace the single letter."
        CustomPlainInput.PlaceholderText = "Custom plain letters"
        CustomCipherInput.PlaceholderText = "Custom key correspondance"
    End Sub
End Class
