using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class CreateNewVehicleUI
    {
        public static void NewVehicleInformation(string i_VehicleLicenseNumber)
        {
            string m_OwnerName;
            string m_OwnerPhoneNumber;
            OutPutMessages.NewVehicleInformationDisplayMenu();
            m_OwnerName = Console.ReadLine();
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 5);
            m_OwnerPhoneNumber = Console.ReadLine();
            if ((UI.BackToPreviewScreen(m_OwnerName)) || (UI.BackToPreviewScreen(m_OwnerPhoneNumber)))
            { //// case the user want to go back to preview menu
                if (UI.IOpenedNewGarage.LicenseNumberExist(i_VehicleLicenseNumber))
                { //// case we made a mistake and want to go back to main manu but already entered vehicle information
                    UI.IOpenedNewGarage.RemoveVehicle(i_VehicleLicenseNumber);
                }

                UI.CreateNewVehicleInTheGarage();
            }

            while (UI.IsTheInputCorrect(m_OwnerPhoneNumber, UI.eInputsToCheck.PhoneNumber, Constants.k_WrongInputPrintingLine) == Constants.k_WrongInput)
            {
                Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
                Console.Write("|  =>                                                    |");
                Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 5);
                m_OwnerPhoneNumber = Console.ReadLine();
            }

            ChooseNewVehicleType (i_VehicleLicenseNumber, m_OwnerName, m_OwnerPhoneNumber);
        }

        public static void ChooseNewVehicleType(string i_VehicleLicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            char i_ChoosenVehicleType;
            OutPutMessages.ChooseNewVehicleTypeDisplayMenu();
            i_ChoosenVehicleType = Console.ReadKey().KeyChar;
            while (i_ChoosenVehicleType != Constants.k_Car && i_ChoosenVehicleType != Constants.k_Motorcycle && i_ChoosenVehicleType != Constants.k_Truck)
            {
                OutPutMessages.PrintWrongMessage();
                i_ChoosenVehicleType = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            if (i_ChoosenVehicleType == Constants.k_Car)
            {
                EnterInformation(i_VehicleLicenseNumber, Constants.k_Car, i_OwnerName, i_OwnerPhoneNumber);
            }
            else if (i_ChoosenVehicleType == Constants.k_Motorcycle)
            {
                EnterInformation(i_VehicleLicenseNumber, Constants.k_Motorcycle, i_OwnerName, i_OwnerPhoneNumber);
            }
            else
            { //// if (i_ChoosenVehicleType == Constants.k_Truck)
                EnterInformation(i_VehicleLicenseNumber, Constants.k_Truck, i_OwnerName, i_OwnerPhoneNumber);
            }
        }
                            
        public static void EnterInformation(string i_VehicleLicenseNumber, char i_VehicleType, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            //// general members
            string i_VehicleModel;
            float i_CurrentEnergyLevel;
            string i_CurrentEnergyLevelSTR;
            float i_CurrentWheelsPSI;
            string i_CurrentWheelsPSISTR;
            ////Engine.eFuelType i_FuelType;
            char i_ChoosenVehicleEngineType;
            string wheelModel;
            
            //// car members
            char i_CarColorChar;
            Car.eColorOfCar i_CarColor;
            int i_NumberOfDoors;
            char i_NumberOfDoorsChar;

            //// motorcycle members
            char i_MotorcycleLicenseTypeChar;
            Motorcycle.eLicenseType i_MotorcycleLicenseType;
            int i_EngineCapacitiyCC;
            string i_EngineCapacitiyCCSTR;

            //// truck members
            bool i_TrunkIsCool;
            char i_TrunkIsCoolChar;
            float i_TrunkCapacityCC;
            string i_TrunkCapacitySTR;

            //// play with functions
            OutPutMessages.VehicleModelDisplayMenu();
            i_VehicleModel = Console.ReadLine();
            OutPutMessages.ChooseEngineTypeDisplayMenu();
            i_ChoosenVehicleEngineType = Console.ReadKey().KeyChar;
            while (i_ChoosenVehicleEngineType != Constants.k_Fuel && i_ChoosenVehicleEngineType != Constants.k_Electric)
            {
                OutPutMessages.PrintWrongMessage();
                i_ChoosenVehicleEngineType = Console.ReadKey().KeyChar;
            }
            ////if (IsItAFuelEngine(i_ChoosenVehicleEngineType))
            ////{ //// case it is a fuel engine
            ////    OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
            ////    i_FuelTypeSign = Console.ReadKey().KeyChar;
            ////    i_FuelType = UI.GetEngineTypeFromChar(i_FuelTypeSign);
            ////}
            ////else
            ////{ //// case it is an electric engine
            ////    i_FuelType = Engine.eFuelType.Electricity;
            ////}

            OutPutMessages.VehicleEnergyLevelDisplayMenu();
            i_CurrentEnergyLevelSTR = Console.ReadLine();
            while (!(float.TryParse(i_CurrentEnergyLevelSTR, out i_CurrentEnergyLevel)))
            { //// case the string input could not convert to float
                OutPutMessages.VehicleEnergyLevelDisplayMenu();
                i_CurrentEnergyLevelSTR = Console.ReadLine();
            }

            OutPutMessages.WheelsModel();
            wheelModel = Console.ReadLine();
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 24, Constants.k_StartPrintingMenuLine + 5);
            i_CurrentWheelsPSISTR = Console.ReadLine();
            while (!(float.TryParse(i_CurrentWheelsPSISTR, out i_CurrentWheelsPSI)))
            { //// case the string input could not convert to float
                Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 24, Constants.k_StartPrintingMenuLine + 5);
                i_CurrentWheelsPSISTR = Console.ReadLine();
            }


            if (i_VehicleType == Constants.k_Car)
            {
                OutPutMessages.CarColorsDisplayMenu();
                i_CarColorChar = Console.ReadKey().KeyChar;
                i_CarColor = GetCarColorFromChar(i_CarColorChar);
                OutPutMessages.NumberOfDoorsDisplayMenu();
                i_NumberOfDoorsChar = Console.ReadKey().KeyChar;
                i_NumberOfDoors = (i_NumberOfDoorsChar - Constants.k_ValueToDecreaseFromCharToGetInt);
                

                CreateNewVehicle.AddNewCarCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_CurrentEnergyLevel, i_CarColor, i_NumberOfDoors, i_ChoosenVehicleEngineType, i_OwnerName, i_OwnerPhoneNumber, wheelModel, i_CurrentWheelsPSI);
            }
            else if (i_VehicleType == Constants.k_Motorcycle)
            {
                OutPutMessages.MotorcycleLicenseDisplayMenu();
                i_MotorcycleLicenseTypeChar = Console.ReadKey().KeyChar;
                i_MotorcycleLicenseType = GetLicenseTypeFromChar(i_MotorcycleLicenseTypeChar);
                OutPutMessages.EngineCapacityCCDisplayMenu();
                i_EngineCapacitiyCCSTR = Console.ReadLine();
                i_EngineCapacitiyCC = int.Parse(i_EngineCapacitiyCCSTR);
               
                CreateNewVehicle.AddNewMotorcycleCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_CurrentEnergyLevel, i_MotorcycleLicenseType, i_EngineCapacitiyCC, i_ChoosenVehicleEngineType, i_OwnerName, i_OwnerPhoneNumber, wheelModel, i_CurrentWheelsPSI);
            }
            else
            { //// if (i_VehicleType == Constants.k_Truck)
                OutPutMessages.TruckDisplayMenu();
                i_TrunkCapacitySTR = Console.ReadLine();
                while (!float.TryParse(i_TrunkCapacitySTR, out i_TrunkCapacityCC))
                {
                    OutPutMessages.TruckDisplayMenu();
                    i_TrunkCapacitySTR = Console.ReadLine();
                }

                i_TrunkIsCoolChar = Console.ReadKey().KeyChar;
                i_TrunkIsCool = IsTheTrunkIsColler(i_TrunkIsCoolChar);
                CreateNewVehicle.AddNewTruckCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_CurrentEnergyLevel, i_TrunkIsCool, i_TrunkCapacityCC, i_OwnerName, i_OwnerPhoneNumber, wheelModel, i_CurrentWheelsPSI);
            }

            Console.Clear();
            OutPutMessages.SuccessMessageDisplayMenu();
            UI.WorkingInTheGarage();
        }
        
        private static bool IsTheTrunkIsColler(char i_TrunkIsCoolerOrNot)
        {
            const bool v_TheTrunkIsCooler = true;
            if (i_TrunkIsCoolerOrNot == Constants.k_TheTrunkISCooler)
            {
                return (v_TheTrunkIsCooler);
            }
            else
            { 
                return (!v_TheTrunkIsCooler);
            }
        }

        private static Car.eColorOfCar GetCarColorFromChar(char i_CharInputForColor)
        {
            if (i_CharInputForColor == Constants.k_ColorGrey)
            {
                return (Car.eColorOfCar.Grey);
            }
            else if (i_CharInputForColor == Constants.k_ColorBlue)
            {
                return (Car.eColorOfCar.Blue);
            }
            else if (i_CharInputForColor == Constants.k_ColorWhite)
            {
                return (Car.eColorOfCar.White);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_ColorBlack)
                return (Car.eColorOfCar.Black);
            }
        }

        private static Motorcycle.eLicenseType GetLicenseTypeFromChar(char i_CharInputForLicenseType)
        {
            if (i_CharInputForLicenseType == Constants.k_LicenseTypeA)
            {
                return (Motorcycle.eLicenseType.A);
            }
            else if (i_CharInputForLicenseType == Constants.k_LicenseTypeA1)
            {
                return (Motorcycle.eLicenseType.A1);
            }
            else if (i_CharInputForLicenseType == Constants.k_LicenseTypeB1)
            {
                return (Motorcycle.eLicenseType.B1);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_LicenseTypeB2)
                return (Motorcycle.eLicenseType.B2);
            }
        }
    }
}
