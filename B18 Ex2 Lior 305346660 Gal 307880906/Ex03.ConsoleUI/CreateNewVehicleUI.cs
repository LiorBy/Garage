using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

            UI.IOpenedNewGarage.AddNewVehicle(i_VehicleLicenseNumber, m_OwnerName, m_OwnerPhoneNumber);
            ChooseNewVehicleType (i_VehicleLicenseNumber);
        }

        public static void ChooseNewVehicleType(string i_VehicleLicenseNumber)
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
                ChooseEngineType(i_VehicleLicenseNumber, Constants.k_Car);
            }
            else if (i_ChoosenVehicleType == Constants.k_Motorcycle)
            {
                ChooseEngineType(i_VehicleLicenseNumber, Constants.k_Motorcycle);
            }
            else
            { //// if (i_ChoosenVehicleType == Constants.k_Truck)
                EnterInformation(i_VehicleLicenseNumber, Constants.k_Fuel, Constants.k_Truck);
            }
        }
        
        public static void ChooseEngineType(string i_VehicleLicenseNumber, char i_CarOrMotorcycle)
        {
            char i_ChoosenVehicleEngineType;
            OutPutMessages.ChooseEngineTypeDisplayMenu();
            i_ChoosenVehicleEngineType = Console.ReadKey().KeyChar;
            while (i_ChoosenVehicleEngineType != Constants.k_Fuel && i_ChoosenVehicleEngineType != Constants.k_Electric)
            {
                OutPutMessages.PrintWrongMessage();
                i_ChoosenVehicleEngineType = Console.ReadKey().KeyChar;
            }

            Console.Clear();
            EnterInformation(i_VehicleLicenseNumber, i_ChoosenVehicleEngineType, i_CarOrMotorcycle);
            // line 79 replace next lines!!!!!!!!!!!!
            ////if (i_CarOrMotorcycle == Constants.k_Car)
            ////{
            ////    EnterCarInformation(i_VehicleLicenseNumber, i_ChoosenVehicleEngineType, i_CarOrMotorcycle);
            ////}
            ////else
            ////{ //// if (i_CarOrMotorcycle == Constants.k_Motorcycle)
            ////    EnterMotorcycleInformation(i_VehicleLicenseNumber, i_ChoosenVehicleEngineType, i_CarOrMotorcycle);
            ////}
        }
              
        public static void EnterInformation(string i_VehicleLicenseNumber, char i_FuelOrElectric, char i_VehicleType)
        {
            //// general members
            string i_VehicleModel;
            float i_CurrentEnergyLevel;
            string i_CurrentEnergyLevelSTR;
            float i_MaxEnergyLevel;
            char i_FuelTypeSign;
            Ex03.GarageLogic.Engine.eFuelType i_FuelType;

            //// car members
            char i_CarColorChar;
            Ex03.GarageLogic.Vehicles.Car.eColorOfCar i_CarColor;
            int i_NumberOfDoors;
            char i_NumberOfDoorsChar;

            //// motorcycle members
            char i_MotorcycleLicenseTypeChar;
            Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType i_MotorcycleLicenseType;
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
            if (IsItAFuelEngine(i_FuelOrElectric))
            { //// case it is a fuel engine
                OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
                i_FuelTypeSign = Console.ReadKey().KeyChar;
                i_FuelType = UI.GetEngineTypeFromChar(i_FuelTypeSign);
            }
            else
            { //// case it is an electric engine
                i_FuelType = Ex03.GarageLogic.Engine.eFuelType.Electricity;
            }

            OutPutMessages.VehicleEnergyLevelDisplayMenu();
            i_CurrentEnergyLevelSTR = Console.ReadLine();
            while (!(float.TryParse(i_CurrentEnergyLevelSTR, out i_CurrentEnergyLevel)))
            { //// case the string input could not convert to float
                OutPutMessages.VehicleEnergyLevelDisplayMenu();
                i_CurrentEnergyLevelSTR = Console.ReadLine();
            }

            if (i_VehicleType == Constants.k_Car)
            {
                OutPutMessages.CarColorsDisplayMenu();
                i_CarColorChar = Console.ReadKey().KeyChar;
                i_CarColor = GetCarColorFromChar(i_CarColorChar);
                OutPutMessages.NumberOfDoorsDisplayMenu();
                i_NumberOfDoorsChar = Console.ReadKey().KeyChar;
                i_NumberOfDoors = (i_NumberOfDoorsChar - Constants.k_ValueToDecreaseFromCharToGetInt);
                if (IsItAFuelEngine(i_FuelOrElectric))
                { //// case it is a fuel engine
                    i_MaxEnergyLevel = Constants.k_CarFuelTankCapacity;
                }
                else
                { //// case it is an electric engine
                    i_MaxEnergyLevel = Constants.k_CarBatteryMaxHours;
                }

                UI.IOpenedNewGarage.AddNewCarCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_CarColor, i_NumberOfDoors, i_FuelType);
            }
            else if (i_VehicleType == Constants.k_Motorcycle)
            {
                OutPutMessages.MotorcycleLicenseDisplayMenu();
                i_MotorcycleLicenseTypeChar = Console.ReadKey().KeyChar;
                i_MotorcycleLicenseType = GetLicenseTypeFromChar(i_MotorcycleLicenseTypeChar);
                OutPutMessages.EngineCapacityCCDisplayMenu();
                i_EngineCapacitiyCCSTR = Console.ReadLine();
                i_EngineCapacitiyCC = int.Parse(i_EngineCapacitiyCCSTR);
                if (IsItAFuelEngine(i_FuelOrElectric))
                { //// case it is a fuel engine
                    i_MaxEnergyLevel = Constants.k_MotorcycleFuelTankCapacity;
                }
                else
                { //// case it is an electric engine
                    i_MaxEnergyLevel = Constants.k_MotorcycleBatteryMaxHours;
                }

                UI.IOpenedNewGarage.AddNewMotorcycleCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_MotorcycleLicenseType, i_EngineCapacitiyCC, i_FuelType);
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
                i_MaxEnergyLevel = Constants.k_TruckFuelTankCapacity;
                UI.IOpenedNewGarage.AddNewTruckCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_TrunkIsCool, i_TrunkCapacityCC, i_FuelType);
            }
            Console.Clear();
            OutPutMessages.SuccessMessageDisplayMenu();
            UI.WorkingInTheGarage();

        }

        private static bool IsItAFuelEngine(char i_FuelOrElectric)
        {
            const bool v_ItsAFuelEngine = true;
            if (i_FuelOrElectric == Constants.k_Fuel)
            {
                return (v_ItsAFuelEngine);
            }
            else
            {
                return (!v_ItsAFuelEngine);
            }
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

        private static Ex03.GarageLogic.Vehicles.Car.eColorOfCar GetCarColorFromChar(char i_CharInputForColor)
        {
            if (i_CharInputForColor == Constants.k_ColorGrey)
            {
                return (Ex03.GarageLogic.Vehicles.Car.eColorOfCar.Grey);
            }
            else if (i_CharInputForColor == Constants.k_ColorBlue)
            {
                return (Ex03.GarageLogic.Vehicles.Car.eColorOfCar.Blue);
            }
            else if (i_CharInputForColor == Constants.k_ColorWhite)
            {
                return (Ex03.GarageLogic.Vehicles.Car.eColorOfCar.White);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_ColorBlack)
                return (Ex03.GarageLogic.Vehicles.Car.eColorOfCar.Black);
            }
        }

        private static Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType GetLicenseTypeFromChar(char i_CharInputForLicenseType)
        {

            if (i_CharInputForLicenseType == Constants.k_LicenseTypeA)
            {
                return (Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType.A);
            }
            else if (i_CharInputForLicenseType == Constants.k_LicenseTypeA1)
            {
                return (Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType.A1);
            }
            else if (i_CharInputForLicenseType == Constants.k_LicenseTypeB1)
            {
                return (Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType.B1);
            }
            else
            { //// if (i_CharInputForColor == Constants.k_LicenseTypeB2)
                return (Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType.B2);
            }
        }





        ////public static void EnterElectricCarInformation(string i_VehicleLicenseNumber)
        ////{
        ////    //// members
        ////    string i_VehicleModel;
        ////    float i_CurrentEnergyLevel;
        ////    string i_CurrentEnergyLevelSTR;
        ////    float i_MaxEnergyLevel = Constants.k_CarBatteryMaxHours;
        ////    char i_CarColorChar;
        ////    Ex03.GarageLogic.Vehicles.Car.eColorOfCar i_CarColor;
        ////    int i_NumberOfDoors;
        ////    char i_NumberOfDoorsChar;
        ////    //// play with functions
        ////    VehicleModelDisplayMenu();
        ////    i_VehicleModel = Console.ReadLine();
        ////    VehicleEnergyLevelDisplayMenu();
        ////    i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    while (!(float.TryParse(i_CurrentEnergyLevelSTR, out i_CurrentEnergyLevel)))
        ////    { //// case the string input could not convert to float
        ////        VehicleEnergyLevelDisplayMenu();
        ////        i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    }
        ////    CarColorsDisplayMenu();
        ////    i_CarColorChar = Console.ReadKey().KeyChar;
        ////    i_CarColor = GetCarColorFromChar(i_CarColorChar);
        ////    NumberOfDoorsDisplayMenu();
        ////    i_NumberOfDoorsChar = Console.ReadKey().KeyChar;
        ////    i_NumberOfDoors = Convert.ToInt32(i_NumberOfDoorsChar);
        ////    UI.IOpenedNewGarage.AddNewCarCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_CarColor, i_NumberOfDoors, Ex03.GarageLogic.Engine.eFuelType.Electricity);

        ////}






        ////public static void EnterCarInformation(string i_VehicleLicenseNumber, char i_FuelOrElectric)
        ////{
        ////    //// members
        ////    string i_VehicleModel;
        ////    float i_CurrentEnergyLevel;
        ////    string i_CurrentEnergyLevelSTR;
        ////    float i_MaxEnergyLevel;
        ////    char i_CarColorChar;
        ////    Ex03.GarageLogic.Vehicles.Car.eColorOfCar i_CarColor;
        ////    Ex03.GarageLogic.Engine.eFuelType i_FuelType;
        ////    int i_NumberOfDoors;
        ////    char i_NumberOfDoorsChar;
        ////    char i_FuelTypeSign;
        ////    //// play with functions
        ////    VehicleModelDisplayMenu();
        ////    i_VehicleModel = Console.ReadLine();
        ////    if (i_FuelOrElectric == Constants.k_Fuel)
        ////    {
        ////        OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
        ////        i_FuelTypeSign = Console.ReadKey().KeyChar;
        ////        i_FuelType = GetEngineTypeFromChar(i_FuelTypeSign);
        ////        i_MaxEnergyLevel = Constants.k_CarFuelTankCapacity;
        ////    }
        ////    else
        ////    {
        ////        i_FuelType = Ex03.GarageLogic.Engine.eFuelType.Electricity;
        ////        i_MaxEnergyLevel = Constants.k_CarBatteryMaxHours;
        ////    }

        ////    i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    while (!(float.TryParse(i_CurrentEnergyLevelSTR, out i_CurrentEnergyLevel)))
        ////    { //// case the string input could not convert to float
        ////        VehicleEnergyLevelDisplayMenu();
        ////        i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    }
        ////    CarColorsDisplayMenu();
        ////    i_CarColorChar = Console.ReadKey().KeyChar;
        ////    i_CarColor = GetCarColorFromChar(i_CarColorChar);
        ////    NumberOfDoorsDisplayMenu();
        ////    i_NumberOfDoorsChar = Console.ReadKey().KeyChar;
        ////    i_NumberOfDoors = Convert.ToInt32(i_NumberOfDoorsChar);
        ////    UI.IOpenedNewGarage.AddNewCarCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_CarColor, i_NumberOfDoors, i_FuelType);


        ////}

        ////public static void EnterMotorcycleInformation(string i_VehicleLicenseNumber, char i_FuelOrElectric)
        ////{
        ////    //// members
        ////    string i_VehicleModel;
        ////    float i_CurrentEnergyLevel;
        ////    string i_CurrentEnergyLevelSTR;
        ////    float i_MaxEnergyLevel;
        ////    char i_FuelTypeSign;
        ////    Ex03.GarageLogic.Engine.eFuelType i_FuelType;
        ////    char i_MotorcycleLicenseTypeChar;
        ////    Ex03.GarageLogic.Vehicles.Motorcycle.eLicenseType i_MotorcycleLicenseType;
        ////    int i_EngineCapacitiyCC;
        ////    char i_EngineCapacitiyCCChar;
        ////    //// play with functions
        ////    VehicleModelDisplayMenu();
        ////    i_VehicleModel = Console.ReadLine();
        ////    if (i_FuelOrElectric == Constants.k_Fuel)
        ////    {
        ////        OutPutMessages.ChooseFuelInVehicleTypeDisplayMenu();
        ////        i_FuelTypeSign = Console.ReadKey().KeyChar;
        ////        i_FuelType = GetEngineTypeFromChar(i_FuelTypeSign);
        ////        i_MaxEnergyLevel = Constants.k_MotorcycleFuelTankCapacity;
        ////    }
        ////    else
        ////    {
        ////        i_FuelType = Ex03.GarageLogic.Engine.eFuelType.Electricity;
        ////        i_MaxEnergyLevel = Constants.k_MotorcycleBatteryMaxHours;
        ////    }

        ////    i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    while (!(float.TryParse(i_CurrentEnergyLevelSTR, out i_CurrentEnergyLevel)))
        ////    { //// case the string input could not convert to float
        ////        VehicleEnergyLevelDisplayMenu();
        ////        i_CurrentEnergyLevelSTR = Console.ReadLine();
        ////    }
        ////    MotorcycleLicenseDisplayMenu();
        ////    i_MotorcycleLicenseTypeChar = Console.ReadKey().KeyChar;
        ////    i_MotorcycleLicenseType = GetLicenseTypeFromChar(i_MotorcycleLicenseTypeChar);
        ////    EngineCapacityCCDisplayMenu();
        ////    i_EngineCapacitiyCCChar = Console.ReadKey().KeyChar;
        ////    i_EngineCapacitiyCC = Convert.ToInt32(i_EngineCapacitiyCCChar);
        ////    UI.IOpenedNewGarage.AddNewMotorcycleCompleteInformation(i_VehicleLicenseNumber, i_VehicleModel, i_MaxEnergyLevel, i_CurrentEnergyLevel, i_MotorcycleLicenseType, i_EngineCapacitiyCC, i_FuelType);

        ////}


        ////public static void EnterFuelTruckInformation(string i_VehicleLicenseNumber)
        ////{
        ////    string i_VehicleModel;
        ////    float i_CurrentEnergyLevel;
        ////    float i_MaxEnergyLevel = Constants.k_TruckFuelTankCapacity;
        ////    Ex03.GarageLogic.FuelEngine.eFuelType FuelType = Ex03.GarageLogic.FuelEngine.eFuelType.Soler;
        ////    bool i_TrunkIsCool;
        ////    float i_TrunkCapacity;

        ////}




    }
}
