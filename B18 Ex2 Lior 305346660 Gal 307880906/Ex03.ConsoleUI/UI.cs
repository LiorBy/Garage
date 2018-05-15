using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        public enum eInputsToCheck
        {
            PhoneNumber,
            ChargingAmount,
            LicenseNumber
        }

        public static Garage IOpenedNewGarage = new Garage();

        public static void WorkingInTheGarage()
        {
            Console.Clear();
            char theDecisionToDoIs = ChooseWhatToDo();
            if (theDecisionToDoIs == Constants.k_NewVehicle)
            {
                CreateNewVehicleInTheGarage();
            }
            else if (theDecisionToDoIs == Constants.k_WantInformation)
            {
                ReceiveInformation();
            }
            else
            { //// theDecisionToDoIs = == Constants.k_UpdateVehicleData
                UpdateVehicleData();
            }
        }

        private static char ChooseWhatToDo()
        {
            ////int theDecisionIs;
            OutPutMessages.ChooseWhatToDoDisplayMenu();
            char decision = Console.ReadKey().KeyChar;
            while (decision != Constants.k_NewVehicle && decision != Constants.k_WantInformation && decision != Constants.k_UpdateVehicleData)
            {
                OutPutMessages.PrintWrongMessage();
                decision = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            return decision;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void ReceiveInformation()
        {
            OutPutMessages.ReceiveInformationDisplayMenu();
            char decision = Console.ReadKey().KeyChar;
            while (decision != Constants.k_AllVehiclesLicenseNumbers && decision != Constants.k_SpecificVehicleFullData && decision != Constants.k_PreviewMenu)
            {
                OutPutMessages.PrintWrongMessage();
                decision = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            try
            {
                if (!BackToPreviewScreen(decision))
                {
                    if (decision == Constants.k_AllVehiclesLicenseNumbers)
                    {
                        PrintAllVehiclesLicenseNumber();
                    }
                    else
                    { //// decision == Constants.k_SpecificVehicleFullData
                        PrintAllDataForSpecificVehicle();
                    }
                }             
            }
            finally
            {
                WorkingInTheGarage();
            }
            
        }
        
        private static void PrintAllVehiclesLicenseNumber()
        {
            OutPutMessages.PrintAllVehiclesLicenseNumberDisplayMenu();
            VehicleInTheGarage.eVehicleStatus VehicleStatusToPrint;
            char decision = Console.ReadKey().KeyChar;
            while (decision != Constants.k_InProgress && decision != Constants.k_WaitingToGetPayment && decision != Constants.k_PaidAndReadyToGo && decision != Constants.k_AllTheVehicles && decision != Constants.k_PreviewMenu)
            {
                OutPutMessages.PrintWrongMessage();
                decision = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            try 
            {
                if (!BackToPreviewScreen(decision))
                {
                    VehicleStatusToPrint = GetVehicleStatusFromChar(decision);
                    if (VehicleStatusToPrint == VehicleInTheGarage.eVehicleStatus.AllStatus)
                    {
                        Console.WriteLine("ALL VEHICLES LICENSE NUMBER : \n");
                    }
                    else
                    {
                        Console.WriteLine("ALL VEHICLES LICENSE NUMBERS IN STATUS {0} : \n", VehicleStatusToPrint);
                    }

                    foreach (KeyValuePair<string, VehicleInTheGarage> i_PrintLicenseNumbers in IOpenedNewGarage.AllVehiclesInTheGarage)
                    {
                        if (VehicleStatusToPrint == VehicleInTheGarage.eVehicleStatus.AllStatus)
                        {
                            Console.WriteLine(i_PrintLicenseNumbers.Key + "\n");
                        }
                        else if (i_PrintLicenseNumbers.Value.StatusInTheGarage == VehicleStatusToPrint)
                        {
                            Console.WriteLine(i_PrintLicenseNumbers.Key + "\n");
                        }
                    }
                }
            }
            finally
            {
                ReceiveInformation();
            }

            Thread.Sleep(5000);
            WorkingInTheGarage();
            Console.Clear();
        }


        private static void PrintAllDataForSpecificVehicle()
        {
            VehicleInTheGarage vehicleToPrint = null;
            string licenseNumberToPrintData;
            OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
            licenseNumberToPrintData = Console.ReadLine();
            if (BackToPreviewScreen(licenseNumberToPrintData))
            { //// return to preview menu
                ReceiveInformation();
            }
            else if (IsTheInputCorrect(licenseNumberToPrintData, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            { //// wrong license number input
                PrintAllDataForSpecificVehicle();
            }
            else
            { //// license number not exist
                while (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToPrintData))
                {
                    //// OutPutMessages.LicenseNumberNotExistMessage();
                    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                    Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                    Thread.Sleep(1500);
                    licenseNumberToPrintData = Console.ReadLine();
                }
                //// license number exist- lets print its information
            }

            IOpenedNewGarage.AllVehiclesInTheGarage.TryGetValue(licenseNumberToPrintData, out vehicleToPrint);
            vehicleToPrint.VehicleInTheGarageInfo();








            //string modelNameMessage = "1.Model Name " + vehicleToPrint.Vehicle.ModelName;
            //string licenseNumberMessage = "2.License Number " + vehicleToPrint.Vehicle.LicenseNumber;
            //string wheelsListSubjectMessage = "6.Wheels List: ";
            //string correntEnergyLevelMessage;
            //string maxEnergyLevelMessage;
            //string TypeEnergyMessage;
            //if (vehicleToPrint.Vehicle.VehicleEngine is FuelEngine)
            //{
            //    FuelEngine tempFuelEngine = (FuelEngine)vehicleToPrint.Vehicle.VehicleEngine;
            //    correntEnergyLevelMessage = "3.Corrent Energy Level " + tempFuelEngine.CurrentEnergyStatus + " Liters";
            //    maxEnergyLevelMessage = "4.Max Energy Level " + tempFuelEngine.MaxEnergyCapacity + " Liters";
            //    TypeEnergyMessage = "5.Fuel Type: " + tempFuelEngine.FuelType;
            //}
            //else
            //{

            //    correntEnergyLevelMessage = "3.Corrent Energy Level " + vehicleToPrint.Vehicle.VehicleEngine.CurrentEnergyStatus + " Hours";
            //    maxEnergyLevelMessage = "4.Max Energy Level " + vehicleToPrint.Vehicle.VehicleEngine.MaxEnergyCapacity + " Hours";
            //    TypeEnergyMessage = "5.Energy Engine ";
            //}

            //string OwnerNameMessage = "9.Owner Name: " + vehicleToPrint.OwnerName;
            //string StatusInTheGarage = "10.Garage Status: " + vehicleToPrint.StatusInTheGarage;
            //Console.WriteLine(string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n", modelNameMessage, licenseNumberMessage, correntEnergyLevelMessage,
            //    maxEnergyLevelMessage, TypeEnergyMessage, wheelsListSubjectMessage, PrintAllWheelsInformationByVehicle(vehicleToPrint.Vehicle)));
            //if (vehicleToPrint.Vehicle is Car)
            //{
            //    PrintCarInformation((Car)vehicleToPrint.Vehicle);
            //}
            //else if (vehicleToPrint.Vehicle is Motorcycle)
            //{
            //    PrintMotorcycleInformation((Motorcycle)vehicleToPrint.Vehicle);
            //}
            //else
            //{
            //    PrintTruckInformation((Truck)vehicleToPrint.Vehicle);
            //}
        }

        //private static StringBuilder PrintAllWheelsInformationByVehicle(Vehicle i_Vehicle)
        //{
        //    StringBuilder wheelsList = new StringBuilder();
        //    int counter = 1;
        //    foreach (Wheel wheel in i_Vehicle.VehicleWheelsList)
        //    {
        //        wheelsList.AppendLine(counter + "." + "Wheel Model " + wheel.ModelName + ", Corrent PSI- " + wheel.CurrentAirPressure + ", Max PSI- " + wheel.MaxAirPressure);
        //    }
        //    return wheelsList;
        //}
        //private static void PrintCarInformation(Car i_car)
        //{
        //    Console.WriteLine("7.Car Color: " + i_car.ColorOfTheCar);
        //    Console.WriteLine("8.Number Of Doors:  " + i_car.NumberOfDoors);
        //}
        //private static void PrintMotorcycleInformation(Motorcycle i_Motorcycle)
        //{
        //    Console.WriteLine("7.Motorcycle License Type: " + i_Motorcycle.LicenseType);
        //    Console.WriteLine("8.Motorcycle Engine Capacity: " + i_Motorcycle.EngineCapacityInCC + " CC");
        //}
        //private static void PrintTruckInformation(Truck i_Truck)
        //{
        //    Console.Write("7.Is The Trunk Is Cooler -->> ");
        //    if (i_Truck.CoolerTrunk)
        //    {
        //        Console.WriteLine("YES ");
        //    }
        //    else
        //    {
        //        Console.WriteLine("NO ");
        //    }

        //    Console.WriteLine("8.Truck Trunk Capacity: " + i_Truck.TrunkCapacity);
        //}





        ////private static void PrintAllDataForSpecificVehicle()
        ////{
        ////    string licenseNumberToPrintData;
        ////    OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
        ////    licenseNumberToPrintData = Console.ReadLine();
        ////    while (IsTheInputCorrect(licenseNumberToPrintData, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
        ////    { //// wrong license number input
        ////        OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
        ////        licenseNumberToPrintData = Console.ReadLine();
        ////    }

        ////    try
        ////    {
        ////        if (!BackToPreviewScreen(licenseNumberToPrintData))
        ////        {
        ////            //// license number not exist
        ////            while (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToPrintData))
        ////            { //// OutPutMessages.LicenseNumberNotExistMessage();
        ////                Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////                Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
        ////                Thread.Sleep(1500);
        ////                licenseNumberToPrintData = Console.ReadLine();
        ////            }
        ////            //// license number exist- lets print its information
        ////            /////
        ////            //////

        ////        }
        ////    }
        ////    finally
        ////    {
        ////        ReceiveInformation();
        ////    }
            
        ////}
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private static void UpdateVehicleData()
        {
            OutPutMessages.UpdateVehicleDataDisplayMenu();
            char decision = Console.ReadKey().KeyChar;
            while (decision != Constants.k_ChangeVehicleStatus && decision != Constants.k_InflateWheels && decision != Constants.k_FillEnergy && decision != Constants.k_PreviewMenu)
            { 
                OutPutMessages.PrintWrongMessage();
                decision = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            if (BackToPreviewScreen(decision))
            {
                WorkingInTheGarage();
            }
            else if (decision == Constants.k_ChangeVehicleStatus)
            {
                ChangeVehicleStatus();
            }
            else if (decision == Constants.k_InflateWheels)
            {
                InflateVehicleWheels();
            }
            else
            { //// decision == Constants.k_FillEnergy
                FillingEnergyInVehicle();
            }
        }

        private static void ChangeVehicleStatus()
        {
            string licenseNumberToChangeStatus;
            char decision;
            OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
            licenseNumberToChangeStatus = Console.ReadLine();
            while (IsTheInputCorrect(licenseNumberToChangeStatus, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            { //// wrong license number input
                OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
                licenseNumberToChangeStatus = Console.ReadLine();
            }

            if (BackToPreviewScreen(licenseNumberToChangeStatus))
            {
                UpdateVehicleData();
            }
            else
            {
                if (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                {
                    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                    Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                    Thread.Sleep(1500);
                    ChangeVehicleStatus();
                }
                else
                {
                    OutPutMessages.ChangeVehicleStatusDisplayMenu();
                    decision = Console.ReadKey().KeyChar;
                    while (decision != Constants.k_InProgress && decision != Constants.k_WaitingToGetPayment && decision != Constants.k_PaidAndReadyToGo && decision != Constants.k_PreviewMenu)
                    {
                        OutPutMessages.PrintWrongMessage();
                        decision = Console.ReadKey().KeyChar;
                    }

                    if (BackToPreviewScreen(decision))
                    {
                        ChangeVehicleStatus();
                    }
                    else
                    { //// (decision == Constants.k_PaidAndReadyToGo)
                        IOpenedNewGarage.UpdateVehicleStatus(licenseNumberToChangeStatus, decision);
                        OutPutMessages.GarageUpdateStatusForExistVehicle();
                        Thread.Sleep(1500);
                        WorkingInTheGarage();
                    }
                }
            }
                                              
        }
        
        private static void InflateVehicleWheels()
        {
            string licenseNumberToChangeStatus;
            OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
            licenseNumberToChangeStatus = Console.ReadLine();
            if (BackToPreviewScreen(licenseNumberToChangeStatus))
            {
                UpdateVehicleData();
            }
            else if (IsTheInputCorrect(licenseNumberToChangeStatus, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            {
                InflateVehicleWheels();
            }
            else
            {
                try
                {
                    while (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                    {
                        Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                        Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                        Thread.Sleep(1500);
                        licenseNumberToChangeStatus = Console.ReadLine();
                    }

                    IOpenedNewGarage.InflateAirInWheels(licenseNumberToChangeStatus);
                    OutPutMessages.SuccessMessageForInflateAction();
                    Thread.Sleep(1500);
                    WorkingInTheGarage();
                    ////if (IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                    ////{
                    ////    IOpenedNewGarage.InflateAirInWheels(licenseNumberToChangeStatus);
                    ////    OutPutMessages.SuccessMessageForInflateAction();
                    ////    Thread.Sleep(2500);
                    ////    WorkingInTheGarage();
                    ////}
                    ////else
                    ////{
                        
                    ////}
                }
                catch (ValueOutOfRangeException InflateFailed)
                {
                    Console.Clear();
                    Console.WriteLine("Catching ValueOutOfRangeException: ");
                    Console.WriteLine(InflateFailed.Message);
                    Thread.Sleep(4500);
                    Console.Clear();
                    InflateVehicleWheels();
                }
            }
            
        }

        private static void FillingEnergyInVehicle()
        {
            string licenseNumberToChangeStatus;
            OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
            licenseNumberToChangeStatus = Console.ReadLine();
            if (BackToPreviewScreen(licenseNumberToChangeStatus))
            {
                UpdateVehicleData();
            }
            else if (IsTheInputCorrect(licenseNumberToChangeStatus, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            {
                FillingEnergyInVehicle();
            }
            else
            {
                try
                {
                    while (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                    { //// case the license number not exist
                        Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                        Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                        Thread.Sleep(1500);
                        licenseNumberToChangeStatus = Console.ReadLine();
                    }

                    FillinFuelOrElectricInVehicle(licenseNumberToChangeStatus);
                }
                catch (Exception FillingEnergyFailed)
                {
                    Console.Clear();
                    Console.WriteLine("Catching Exception : \n");
                    Console.WriteLine(FillingEnergyFailed.Message);
                    Thread.Sleep(4500);
                    Console.Clear();
                    FillingEnergyInVehicle();
                    ///////////////////////////////////////////////////////
                }
            }         
        }

        private static void FillinFuelOrElectricInVehicle(string i_LicenseNumberOfVehicleToFill)
        {
            char FuelTypeSign;

            FuelEngine.eFuelType FuelTypeToFill;
            string EnergyAmountToAddSTR;
            float EnergyAmountToAdd;
            if (IOpenedNewGarage.IsItAFuelEngine(i_LicenseNumberOfVehicleToFill))
            { //// this is a fuel engine
                OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
                FuelTypeSign = Console.ReadKey().KeyChar;
                FuelTypeToFill = GetFuelTypeFromChar(FuelTypeSign);
                OutPutMessages.FillingFuelInVehicleChooseAmountDisplayMenu();
            }
            else
            { //// this is an electric engine
                OutPutMessages.ChargingElectricInVehicleDisplayMenu();
                FuelTypeToFill = Engine.eFuelType.Electricity;
            }

            EnergyAmountToAddSTR = Console.ReadLine();
            if (BackToPreviewScreen(EnergyAmountToAddSTR))
            { //// case the user want to go back to preview menu
                FillingEnergyInVehicle();
            }
            else if (!(float.TryParse(EnergyAmountToAddSTR, out EnergyAmountToAdd)))
            { //// case the string input could not convert to float
                FillinFuelOrElectricInVehicle(i_LicenseNumberOfVehicleToFill);
            }
            else
            {
                IOpenedNewGarage.FillingEnergyInTheVehicle(EnergyAmountToAdd, FuelTypeToFill, i_LicenseNumberOfVehicleToFill);
                OutPutMessages.SuccessMessageForFillingEnergyAction();
                Thread.Sleep(1500);
                WorkingInTheGarage();
            }
        }     

        public static FuelEngine.eFuelType GetFuelTypeFromChar(char i_CharInputForEnergyType)
        {
            if (i_CharInputForEnergyType == Constants.k_Octan95)
            {
                return (FuelEngine.eFuelType.Octan95);
            }
            else if (i_CharInputForEnergyType == Constants.k_Octan96)
            {
                return (FuelEngine.eFuelType.Octan96);
            }
            else if (i_CharInputForEnergyType == Constants.k_Octan98)
            {
                return (FuelEngine.eFuelType.Octan98);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_Soler)
                return (FuelEngine.eFuelType.Soler);
            }
        }

        public static VehicleInTheGarage.eVehicleStatus GetVehicleStatusFromChar(char i_CharInputForVehicleStatus)
        {
            if (i_CharInputForVehicleStatus == Constants.k_InProgress)
            {
                return (VehicleInTheGarage.eVehicleStatus.InProgress);
            }
            else if (i_CharInputForVehicleStatus == Constants.k_WaitingToGetPayment)
            {
                return (VehicleInTheGarage.eVehicleStatus.WaitingToGetPayment);
            }
            else if (i_CharInputForVehicleStatus == Constants.k_PaidAndReadyToGo)
            {
                return (VehicleInTheGarage.eVehicleStatus.PaidAndReadyToGo);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_Soler)
                return (VehicleInTheGarage.eVehicleStatus.AllStatus);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void CreateNewVehicleInTheGarage()
        {
            string licenseNumberToCreateVehicle;
            OutPutMessages.AskingForVehicleLicenseNumberDisplayMenu();
            licenseNumberToCreateVehicle = Console.ReadLine();
            if (BackToPreviewScreen(licenseNumberToCreateVehicle))
            {
                WorkingInTheGarage();
            }

            else if (IsTheInputCorrect(licenseNumberToCreateVehicle, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            {
                CreateNewVehicleInTheGarage();
            }
            else if (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToCreateVehicle))
            { //// case the license number doesn't exist--> we can enter new vehicle
                CreateNewVehicleUI.NewVehicleInformation(licenseNumberToCreateVehicle);

            }
            else
            {
                OutPutMessages.ChangeStatusForExistVehicle();
                IOpenedNewGarage.UpdateVehicleStatus(licenseNumberToCreateVehicle, Constants.k_InProgress);
                WorkingInTheGarage();
            }

        }

        public static bool IsTheInputCorrect(string i_StringToCheck, eInputsToCheck i_TypeOfInput, int i_LineToPrint = 3)
        {
            const bool v_CorrectInput = true;
            if (i_TypeOfInput == eInputsToCheck.PhoneNumber)
            {
                if (Regex.IsMatch(i_StringToCheck, "^[0-9]+$"))
                {
                    return (v_CorrectInput);
                }
            }
            else
            { //// eInputsToCheck == eInputsToCheck.LicenseNumber
                if (Regex.IsMatch(i_StringToCheck, "^[a-z,A-Z,0-9]+"))
                {
                    return (v_CorrectInput);
                }
            }

            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + i_LineToPrint);
            Console.Write(Constants.k_WrongInputMessage);
            Thread.Sleep(2000);
            return (!v_CorrectInput);
        }

        public static bool BackToPreviewScreen(char i_CharToCheck)
        {
            const bool v_GoBack = true;
            if(i_CharToCheck == Constants.k_PreviewMenu)
             {
                Console.Clear();
                return (v_GoBack);
            }
            else
            {
                return (!v_GoBack);
            }
        }

        public static bool BackToPreviewScreen(string i_StringToCheck)
        {
            const bool v_GoBack = true;
            if (i_StringToCheck.CompareTo(Constants.k_PreviewMenuSTR) == 0)
            {
                Console.Clear();
                return (v_GoBack);
            }
            else
            {
                return (!v_GoBack);
            }
        }


        
    }
}


////private static void FillingFuelInVehicle(string i_LicenseNumberOfVehicleToFill)
////{
////    string LitersToFillSTR;
////    float LitersToFill;
////    Ex03.GarageLogic.Engine.eFuelType FuelTypeToFill;
////    char FuelTypeSign;
////    OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
////    FuelTypeSign = Console.ReadKey().KeyChar;
////    OutPutMessages.FillingFuelInVehicleChooseAmountDisplayMenu();
////    LitersToFillSTR = Console.ReadLine();
////    FuelTypeToFill = GetEngineTypeFromChar(FuelTypeSign);
////    if ((BackToPreviewScreen(LitersToFillSTR)) || (BackToPreviewScreen(FuelTypeSign)))
////    { //// case the user want to go back to preview menu
////        FillingEnergyInVehicle();
////    }
////    else if (!(float.TryParse(LitersToFillSTR, out LitersToFill)))
////    { //// case the string input could not convert to float
////        FillingFuelInVehicle(i_LicenseNumberOfVehicleToFill);
////    }
////    else
////    {                                
////        IOpenedNewGarage.FillingEnergyInTheVehicle(LitersToFill, FuelTypeToFill, i_LicenseNumberOfVehicleToFill);
////        Console.Write("fgdfgfdgdfhgfdhgdfthfghsfghbfg");
////        Thread.Sleep(6000);
////    }


////}

////private static void ChargingElectricInVehicle(string i_LicenseNumberOfVehicleToFill)
////{
////    string minutesToChargeSTR;
////    float minutesToCharge;
////    OutPutMessages.ChargingElectricInVehicleDisplayMenu();
////    minutesToChargeSTR = Console.ReadLine();

////    if (BackToPreviewScreen(minutesToChargeSTR))
////    {
////        FillingEnergyInVehicle();
////    }
////    else if (!(float.TryParse(minutesToChargeSTR, out minutesToCharge)))
////    {
////        ChargingElectricInVehicle(i_LicenseNumberOfVehicleToFill);
////    }
////}