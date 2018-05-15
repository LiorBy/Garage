using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class OutPutMessages
    {
        public static void ChooseWhatToDoDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  1. ENTER NEW VEHICLE TO THE GARAGE       (1)          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  2. INFORMATION                           (2)          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  3. UPDATE VEHICLE DATA                   (3)          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  press 'p' at any time for preview menu                |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void ReceiveInformationDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  WHAT INFORMATION ARE YOU LOOKING FOR?                 |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  1. SHOW LICENSE NUMBER OF ALL THE VEHICLES        (1) |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  2. SHOW ALL THE DATA FOR SPECIFIC VEHICLE         (2) |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void PrintAllVehiclesLicenseNumberDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  PRINT LICENSE NUMBER FOR VEHICLES IN STATUS :         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  1. IN PROGRESS             (1)                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  2. WAITING TO GET PAYMENT  (2)                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  3. PAID AND READY TO GO    (3)                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  4. ALL THE VEHICLES        (4)                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void AskingForVehicleLicenseNumberDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  PLEASE ENTER VEHICLE LICENSE NUMBER :                 |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void UpdateVehicleDataDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  WHAT WOULD YOU LIKE TO DO :                           |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  1. CHANGE VEHICLE STATUS IN THE GARAGE          (1)   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  2. INFLATE VEHICLE WHEELS TO MAXIMUM            (2)   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  3. FILL ENERGY IN THE VEHICLE                   (3)   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void ChangeVehicleStatusDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  SELECT THE NEW STATUS OF THE VEHICLE :                |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  1. IN PROGRESS                                   (1)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  2. WAITING TO GET PAYMENT                        (2)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  3. PAID AND READY TO GO                          (3)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void ChooseFuelInVehicleTypeDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  CHOOSE ENGINE FUEL TYPE :                             |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  1. OCTAN 95                                      (1)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  2. OCTAN 96                                      (2)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  3. OCTAN 98                                      (3)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  4. SOLER                                         (4)  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void FillingFuelInVehicleChooseAmountDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  ENTER AMOUNT OF FUEL TO FILL :                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void ChargingElectricInVehicleDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|  ENTER TIME TO CHARGE (IN MINUTES) :                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void PrintWrongMessage()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        | ");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write(Constants.k_WrongInputMessage);
        }

        public static void VehicleModelDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                 --- VEHICLE MODEL ---                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  MODEL :                                               |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 11, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void VehicleEnergyLevelDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                --- ENERGY LEVEL ---                    |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  CURRENT ENERGY LEVEL :                                |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 26, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void CarColorsDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                   --- COLOR ---                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|   1) GREY                         2) BLUE              |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|   3) WHITE                        4) BLACK             |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void NumberOfDoorsDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                ---NUMBER OF DOORS ---                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|              2                      3                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|              4                      5                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void TruckDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- TRUCK INFORMATION ---                |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  TRUNK CAPACITY IS :                                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  IS THE TRUNK COOLED ?                                 |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|      1) YES                   2) NO                    |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 23, Constants.k_StartPrintingMenuLine + 2);
        }

        public static void MotorcycleLicenseDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                    --- LICENSE ---                     |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|             1) A                    2) A1              |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|             3) B1                   4) B2              |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void EngineCapacityCCDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                 --- ENGINE CAPACITY ---                |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  ENGINE CAPACITY IN CC IS :                            |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 30, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void SuccessMessageDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|                --- CONFIRMATION ---                    |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|         NEW VEHICLE ENTERD SUCCESSFULLY INTO           |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                  LIOR&GAL GARAGE                       |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 26, Constants.k_StartPrintingMenuLine + 3);
            Thread.Sleep(2000);
        }

        public static void NewVehicleInformationDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|            ---NEW VEHICLE INFORMATION---               |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  OWNER NAME :                                          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  =>                                                    |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  OWNER PHONE NUMBER :                                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  =>                                                    |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void ChooseNewVehicleTypeDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|            ---NEW VEHICLE INFORMATION---               |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  THE VEHICLE TYPE IS :                                 |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  1) CAR                                    (1)         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  2) MOTORCYCLE                             (2)         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  3) TRUCK                                  (3)         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void ChooseEngineTypeDisplayMenu()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|            ---NEW VEHICLE INFORMATION---               |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|  THE VEHICLE ENGINE TYPE IS :                          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  1) FUEL                                   (1)         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  2) ELECTRIC                               (2)         |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        }

        public static void ChangeStatusForExistVehicle()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  LICENSE NUMBER ALREADY EXIST IN THE GARAGE!!          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  CHANGING ITS STATUS TO :  IN PROGRESS                 |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void SuccessMessageForInflateAction()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|            SUCCESSFULLY INFLATED ALL WHEELS!           |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void GarageUpdateStatusForExistVehicle()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|            NEW STATUS SUCCESSFULLY UPDATED!            |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void SuccessMessageForFillingEnergyAction()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|          SUCCESSFULLY FILLING VEHICLE ENERGY!          |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void LicenseNumberNotExistMessage()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  LICENSE NUMBER NOT EXIST IN THE GARAGE!!              |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|  PLEASE VERIFY YOUR NUMBER AND TRY AGAIN               |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  OR RETURN TO PREVIEW MENU                             |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|  BY PRESSING->      p                                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 4, Constants.k_StartPrintingMenuLine + 6);
        }

        public static void WheelsModel()
        {
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
            Console.Write("|               --- SYSTEM MESSAGE ---                   |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
            Console.Write("|  WHEELS MODEL IS :                                     |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
            Console.Write("|  CURRENT WHEELS PSI :                                  |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
            Console.Write("|                                                        |");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 21, Constants.k_StartPrintingMenuLine + 3);
        }
        ////public static void ElectricCarDisplayMenu()
        ////{
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
        ////    Console.Write("|            ---ELECTRIC CAR INFORMATION---              |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
        ////    Console.Write("|  MODEL :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
        ////    Console.Write("|  COLOR :  1- GREY    2- BLUE    3- WHITE     4- BLACK  |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
        ////    Console.Write("|  NUMBER OF DOORS :      2   /   3   /   4   /   5      |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
        ////    Console.Write("|  CURRENT BATTERY LEVEL :                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////    Console.Write("|                                                        |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        ////}

        ////public static void FuelCarDisplayMenu()
        ////{
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
        ////    Console.Write("|             ---FUEL CAR INFORMATION---                 |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
        ////    Console.Write("|  MODEL :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
        ////    Console.Write("|  COLOR :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
        ////    Console.Write("|  NUMBER OF DOORS :                                     |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
        ////    Console.Write("|  CURRENT FUEL STATUS :                                 |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////    Console.Write("|                                                        |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        ////}

        ////public static void ElectricMotorcycleDisplayMenu()
        ////{
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
        ////    Console.Write("|         ---ELECTRIC MOTORCYCLE INFORMATION---          |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
        ////    Console.Write("|  MODEL :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
        ////    Console.Write("|  COLOR :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
        ////    Console.Write("|  NUMBER OF DOORS :                                     |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
        ////    Console.Write("|  CURRENT BATTERY LEVEL :                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////    Console.Write("|                                                        |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        ////}

        ////public static void FuelMotorcycleDisplayMenu()
        ////{
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
        ////    Console.Write("|           ---FUEL MOTORCYCLE INFORMATION---            |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
        ////    Console.Write("|  MODEL :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
        ////    Console.Write("|  COLOR :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
        ////    Console.Write("|  NUMBER OF DOORS :                                     |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
        ////    Console.Write("|  CURRENT FUEL STATUS :                                 |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////    Console.Write("|                                                        |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        ////}



        ////public static void FuelTrunkDisplayMenu()
        ////{
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 1);
        ////    Console.Write("|             ---FUEL TRUNK INFORMATION---               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 2);
        ////    Console.Write("|  MODEL :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 3);
        ////    Console.Write("|  COLOR :                                               |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 4);
        ////    Console.Write("|  NUMBER OF DOORS :                                     |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 5);
        ////    Console.Write("|  CURRENT FUEL STATUS :                                 |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 6);
        ////    Console.Write("|                                                        |");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn, Constants.k_StartPrintingMenuLine + 7);
        ////    Console.Write("----------------------------------------------------------");
        ////    Console.SetCursorPosition(Constants.k_StartPrintingMenuColumn + 6, Constants.k_StartPrintingMenuLine + 3);
        ////}
    }
}
