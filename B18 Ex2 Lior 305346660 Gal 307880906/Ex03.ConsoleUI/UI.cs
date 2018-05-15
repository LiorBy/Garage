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
            Ex02.ConsoleUtils.Screen.Clear();
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

            Ex02.ConsoleUtils.Screen.Clear();
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

            Ex02.ConsoleUtils.Screen.Clear();
            if (BackToPreviewScreen(decision))
            {
                WorkingInTheGarage();
            }
            else if (decision == Constants.k_AllVehiclesLicenseNumbers)
            {
                PrintAllVehiclesLicenseNumber();
            }
            else
            { //// decision == Constants.k_SpecificVehicleFullData
                PrintAllDataForSpecificVehicle();
            }
        }
        
        private static void PrintAllVehiclesLicenseNumber()
        {
            OutPutMessages.PrintAllVehiclesLicenseNumberDisplayMenu();
            Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus VehicleStatusToPrint;
            char decision = Console.ReadKey().KeyChar;
            while (decision != Constants.k_InProgress && decision != Constants.k_WaitingToGetPayment && decision != Constants.k_PaidAndReadyToGo && decision != Constants.k_AllTheVehicles && decision != Constants.k_PreviewMenu)
            {
                OutPutMessages.PrintWrongMessage();
                decision = Console.ReadKey().KeyChar;
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (BackToPreviewScreen(decision))
            {
                ReceiveInformation();
            }

            VehicleStatusToPrint = GetVehicleStatusFromChar(decision);
            Ex02.ConsoleUtils.Screen.Clear();
            if (VehicleStatusToPrint == Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.AllStatus)
            {
                Console.WriteLine("ALL VEHICLES LICENSE NUMBERS : \n");
            }
            else
            {
                Console.WriteLine("ALL VEHICLES LICENSE NUMBERS IN STATUS {0} : \n", VehicleStatusToPrint);
            }

            foreach (KeyValuePair<string, VehicleInTheGarage> i_PrintLicenseNumbers in IOpenedNewGarage.m_MyGarage)
            {
                if (VehicleStatusToPrint == Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.AllStatus)
                {
                    Console.WriteLine(i_PrintLicenseNumbers.Key + "\n");
                }
                else if(i_PrintLicenseNumbers.Value.UpdateVehicleStatus == VehicleStatusToPrint)
                {
                    Console.WriteLine(i_PrintLicenseNumbers.Key + "\n");
                }
            }

            Thread.Sleep(10000);
            WorkingInTheGarage();
            Ex02.ConsoleUtils.Screen.Clear();
        }
        
        private static void PrintAllDataForSpecificVehicle()
        {
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
            else if (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToPrintData))
            { //// license number not exist
                OutPutMessages.LicenseNumberNotExistMessage();
                PrintAllDataForSpecificVehicle();
            }
            else
            { //// license number exist- lets print its information

            }



        }
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

            Ex02.ConsoleUtils.Screen.Clear();
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
            if (BackToPreviewScreen(licenseNumberToChangeStatus))
            {
                UpdateVehicleData();
            }
            else if (IsTheInputCorrect(licenseNumberToChangeStatus, eInputsToCheck.LicenseNumber) == Constants.k_WrongInput)
            {
                ChangeVehicleStatus();
            }
            else if (!IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
            {
                Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                Thread.Sleep(2500);
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
                    Thread.Sleep(2500);
                    WorkingInTheGarage();
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
                    if (IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                    {
                        IOpenedNewGarage.InflateAirInWheels(licenseNumberToChangeStatus);
                        OutPutMessages.SuccessMessageForInflateAction();
                        Thread.Sleep(2500);
                        WorkingInTheGarage();
                    }
                    else
                    {
                        Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                        Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                        Thread.Sleep(2500);
                        InflateVehicleWheels();
                    }
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException InflateFailed)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    Console.WriteLine("Catching ValueOutOfRangeException: ");
                    Console.WriteLine(InflateFailed.Message);
                    Thread.Sleep(5500);
                    Ex02.ConsoleUtils.Screen.Clear();
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
                    if (IOpenedNewGarage.LicenseNumberExist(licenseNumberToChangeStatus))
                    { //// case the license number exist
                        FillinFuelOrElectricInVehicle(licenseNumberToChangeStatus);
                    }
                    else
                    {
                        Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
                        Console.Write("|  THE LICENSE NUMBER YOU ENTERED NOT EXIST              |");
                        Thread.Sleep(2500);
                        FillingEnergyInVehicle();
                    }
                }
                catch (Exception FillingEnergyFailed)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    Console.WriteLine("Catching Exception : \n");
                    Console.WriteLine(FillingEnergyFailed.Message);
                    Thread.Sleep(5500);
                    Ex02.ConsoleUtils.Screen.Clear();
                    FillingEnergyInVehicle();
                    ///////////////////////////////////////////////////////
                }
            }         
        }

        private static void FillinFuelOrElectricInVehicle(string i_LicenseNumberOfVehicleToFill)
        {
            char FuelTypeSign;

            Ex03.GarageLogic.Engine.eFuelType FuelTypeToFill;
            string EnergyAmountToAddSTR;
            float EnergyAmountToAdd;
            if (IOpenedNewGarage.IsItAFuelEngine(i_LicenseNumberOfVehicleToFill))
            { //// this is a fuel engine
                OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
                FuelTypeSign = Console.ReadKey().KeyChar;
                FuelTypeToFill = GetEngineTypeFromChar(FuelTypeSign);
                OutPutMessages.FillingFuelInVehicleChooseAmountDisplayMenu();
            }
            else
            { //// this is an electric engine
                OutPutMessages.ChargingElectricInVehicleDisplayMenu();
                FuelTypeToFill = Ex03.GarageLogic.Engine.eFuelType.Electricity;
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
                Thread.Sleep(2500);
                WorkingInTheGarage();
            }
        }     

        public static Ex03.GarageLogic.Engine.eFuelType GetEngineTypeFromChar(char i_CharInputForEnergyType)
        {
            if (i_CharInputForEnergyType == Constants.k_Octan95)
            {
                return (Ex03.GarageLogic.Engine.eFuelType.Octan95);
            }
            else if (i_CharInputForEnergyType == Constants.k_Octan96)
            {
                return (Ex03.GarageLogic.Engine.eFuelType.Octan96);
            }
            else if (i_CharInputForEnergyType == Constants.k_Octan98)
            {
                return (Ex03.GarageLogic.Engine.eFuelType.Octan98);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_Soler)
                return (Ex03.GarageLogic.Engine.eFuelType.Soler);
            }
        }

        public static Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus GetVehicleStatusFromChar(char i_CharInputForVehicleStatus)
        {
            if (i_CharInputForVehicleStatus == Constants.k_InProgress)
            {
                return (Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.InProgress);
            }
            else if (i_CharInputForVehicleStatus == Constants.k_WaitingToGetPayment)
            {
                return (Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.WaitingToGetPayment);
            }
            else if (i_CharInputForVehicleStatus == Constants.k_PaidAndReadyToGo)
            {
                return (Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.PaidAndReadyToGo);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_Soler)
                return (Ex03.GarageLogic.VehicleInTheGarage.eVehicleStatus.AllStatus);
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
                Ex02.ConsoleUtils.Screen.Clear();
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
                Ex02.ConsoleUtils.Screen.Clear();
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