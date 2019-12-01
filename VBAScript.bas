SUB VBAScript
  'MACROMENU Set VBAScript Properties
  'MACROKEY C
  'MACRODESCRIPTION Fuck

Rem References.AddFromGuid _
Rem GUID:=strGUID, Major:=1, Minor:=0 
Rem GetProperty "Value", Temp$
Rem MsgBox(Temp)
Rem part=InputBox("You are fucked.","Fucked part","J1")
Rem FindParts part, TRUE
Rem PlaceBlock -0.4, -0.2, 1.6, 2.8, "", "", "Fucked", "DEFAULT"
Rem pin=InputBox("You are fucked.","Fucked pin","GPIO_Fucked")
Rem PlacePin -0.3, 0.3, "Fucked", "output", FALSE
Rem PlaceWire 0, 0, -1, 0
Rem GetProperty "Value", Temp$


Dim xlApp As Object
Dim WB As Object
Dim SHT As Object
Rem Dim SHT_CON As Object

Set xlApp = CreateObject("Excel.Application")
Set WB = xlApp.Workbooks.Open("D:\ConPins.xls")
Set SHT = WB.Worksheets(1)
Rem Set SHT_CON = WB.Worksheets(2)

path=InputBox("You are fucked.","Fucked path",SHT.Cells(1,5).Value)
part=InputBox("You are fucked.","Fucked part",SHT.Cells(2,5).Value)
Rem path=InputBox("You are fucked.","Fucked path","E:\XM_EE.olb")
Rem part=InputBox("You are fucked.","Fucked part","J_ASE6H4010")
PlacePart 0, 0, path, part, "", FALSE

Dim PinCount As Integer
Dim ColumnCount As Integer
Dim Width
PinCount = Int(SHT.Cells(3,5).Value)
ColumnCount = (PinCount/2)
Width = Val(SHT.Cells(4,5).Value)

PlaceWire -0.3, 0.1, -0.8, 0.1
PlaceGround -0.1, 0, "E:\capsym.olb", "GND", "GND"
GoToRelative 0.1, 0.1

For i = 1 To 2
	For j = 1 To ColumnCount
		If(SHT.Cells(j,i).Value="NC") Then
			if(i=1) Then
				PlaceNoConnect 0.5, 0.1
				GoToRelative -0.5, 0
			Else
				PlaceNoConnect 0, 0.1
				
			End If				
		Else
			PlaceWire 0.5, 0.1, 0, 0.1
			If(SHT.Cells(j,i).Value="GND") Then
				if(i=1) Then
					PlaceGround -0.1, 0, "E:\capsym.olb", "GND", "GND"
					GoToRelative 0.1, 0
				Else
					PlaceGround 0.4, 0, "E:\capsym.olb", "GND", "GND"
					GoToRelative -0.4, 0
				End If						
			Else
				PlaceNetAlias 0.1, 0, SHT.Cells(j,i).Value
				GoToRelative -0.1, 0
			End If
		End If
	Next j
	GoToRelative Width+0.5, -0.1*(ColumnCount)
Next i

GoToRelative -Width-0.5, 0.1*(ColumnCount)

GoToRelative 0.5, 0.2
PlaceWire 0, 0, -0.5, 0
PlaceGround 0.4, 0, "E:\capsym.olb", "GND", "GND"
GoToRelative -0.4, 0

GoToRelative 0.5, -0.1*(ColumnCount)-0.3
PlaceWire 0, 0, -0.5, 0
PlaceGround 0.4, 0, "E:\capsym.olb", "GND", "GND"
GoToRelative -0.4, 0

GoToRelative -Width, 0.1*(ColumnCount)+0.3
PlaceWire 0, 0, -0.5, 0
PlaceGround -0.1, 0, "E:\capsym.olb", "GND", "GND"

WB.Close()

END SUB