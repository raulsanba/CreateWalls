﻿using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using CreateWallsDesignAutomation;

namespace CreateWallsCommon
{
    [TransactionAttribute(TransactionMode.Manual)]
	[RegenerationAttribute(RegenerationOption.Manual)]
	class ThisApplication : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			//Get application and document objects
			UIApplication uiApp = commandData.Application;
			UIDocument uidoc = uiApp.ActiveUIDocument;
			Document doc = uiApp.ActiveUIDocument.Document;
			Application app = uiApp.Application;


			//string ruta = App.ExecutingAssemblyPath;

			// Get Active View
			View activeView = uidoc.ActiveView;

			//open ()
			#region MACRO

			#region Ejecución de Script

			BUTTON_GENERAL();


			#endregion

			#region BUTTON GENERAL

			void BUTTON_GENERAL() // Dividir Muros sin y con Ventanas, Ingresando el Valor del Ancho del Panel Deseado .
			{
				try
				{

					#region form1

					//               // form1
					//               //<<----------------------------------------------------INPUTS---------------------------------------------------------->>

					//               //level
					//               string level_string = "Nivel 1";
					//Level level = GetLevel(level_string); // 1.

					//// coordenadas XYZ(x,y,z)
					//XYZ stPoint = new XYZ(0, 0, 0); // 2.
					//XYZ endPoint = new XYZ(0, 0, 0); // 3.

					//// Dimensions
					//// type of House Shapes :  square, rectangle, triangle
					//string n = "rectangle"; // 4.

					//// Doors in the RIGHT
					//bool door_RightWall = false;
					//bool wind_RigthWall = true; // 5.


					//// Ventanas in the LEFT
					//bool door_LeftWall = true; // 6.
					//bool wind_LeftWall = false;

					//double _heigth_ = 2880 / 304.8; // 7.
					//double h_window = 800 / 304.8; // 8.

					////<<------------------------------------------------------INPUTS-------------------------------------------------------->>


					//using (var form = new Form1())
					//{
					//	form.ShowDialog();

					//	if (form.DialogResult == forms.DialogResult.Cancel) return;

					//	if (form.DialogResult == forms.DialogResult.OK)
					//	{





					//	}

					//}

					// close form1
					#endregion

					string filepathJson = @"A:\Users\mgray\OneDrive - ARCO\Desktop\tempJson.json";
					ReactJson jsonDeserialized = ReactJson.Parse(filepathJson);

					CreateWallsCommon.Construct c = new CreateWallsCommon.Construct();
					c.CreateWalls(jsonDeserialized, doc);
					c.CreateFloors(jsonDeserialized, doc);
				}
				catch (Exception e)
				{
					//TaskDialog.Show("Error", e.Message.ToString());
					throw;
				}
				finally
				{

				}

			} // Dividir Muros sin y con Ventanas, Ingresando el Valor del Ancho del Panel Deseado . Pick Object Selection .

			#endregion

			

			#endregion
			//close ()

			return Result.Succeeded;
		}
	}
}
