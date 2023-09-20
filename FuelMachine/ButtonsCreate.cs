using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelMachine.Models;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FuelMachine
{
    internal class ButtonsCreate
    {
        public InlineKeyboardMarkup ButtonModelsCreate(CallbackQuery callbackQuery)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var carsM = db.CarModels.Select(p => new
                {
                    Name = p.ModelName,
                    IdModel = p.Id,
                    IdCar = p.CarId,
                    Car = p.Car.CarName
                }).Where(c => c.IdCar == int.Parse(callbackQuery.Data)).ToList();
                var first = carsM.FirstOrDefault();
                callbackQuery.Message.Text = first.Car;
                var buttonList = new List<List<InlineKeyboardButton>>
                        {
                            new List <InlineKeyboardButton>()
                        };
                int modIndex = 0;
                int buttonListIndex = 0;
                foreach (var c in carsM)
                {
                    callbackQuery.Message.Text = c.Car;
                    buttonList[buttonListIndex]
                    .Add(InlineKeyboardButton.WithCallbackData($"{c.Name}", $"{c.Name}"));
                    modIndex++;
                    if (modIndex % 5 == 0)
                    {
                        buttonListIndex++;
                        buttonList.Add(new List<InlineKeyboardButton>());
                    }
                }
                InlineKeyboardMarkup replyModels = new InlineKeyboardMarkup(buttonList);
                return replyModels;
            }

        }
        public InlineKeyboardMarkup ButtonCarsMarkCreate()
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var cars = db.Cars.Select(p => new
                {
                    Name = p.CarName,
                    IdCar = p.Id,
                }).ToList();

                var buttonList = new List<List<InlineKeyboardButton>>
                        {
                            new List <InlineKeyboardButton>()
                        };
                int carIndex = 0;
                int buttonListIndex = 0;
                foreach (var c in cars)
                {
                    buttonList[buttonListIndex]
                    .Add(InlineKeyboardButton.WithCallbackData($"{c.Name}", $"{c.IdCar}"));
                    carIndex++;
                    if (carIndex % 7 == 0)
                    {
                        buttonListIndex++;
                        buttonList.Add(new List<InlineKeyboardButton>());
                    }
                }

                InlineKeyboardMarkup replyMarks = new InlineKeyboardMarkup(buttonList);
                return replyMarks;
            }
        }
        public InlineKeyboardMarkup ButtonAirConditionCreate()
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var cars = db.AirConditioners.Select(p => new
                {
                    AirConditionerPresent = p.IsAirConditionerPresent,
                    Coefficient = p.Coefficient,
                    CondtionerId = p.Id
                }).ToList();

                var buttonList = new List<List<InlineKeyboardButton>>
                        {
                            new List <InlineKeyboardButton>()
                        };
                int acIndex = 0;
                int buttonListIndex = 0;
                foreach (var c in cars)
                {
                    buttonList[buttonListIndex]
                    .Add(InlineKeyboardButton.WithCallbackData($"{c.AirConditionerPresent}", $"{c.AirConditionerPresent}"));
                    acIndex++;
                    if (acIndex % 2 == 0)
                    {
                        buttonListIndex++;
                        buttonList.Add(new List<InlineKeyboardButton>());
                    }
                }

                InlineKeyboardMarkup replyCond = new InlineKeyboardMarkup(buttonList);
                return replyCond;
            }
        }
        public InlineKeyboardMarkup ButtonTownsCreate()
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var cars = db.Towns.Select(p => new
                {
                    TownName = p.TownName,
                    Coefficient = p.Coefficient,
                    TownId = p.Id
                }).ToList();

                var buttonList = new List<List<InlineKeyboardButton>>
                        {
                            new List <InlineKeyboardButton>()
                        };
                int townIndex = 0;
                int buttonListIndex = 0;
                foreach (var c in cars)
                {
                    buttonList[buttonListIndex]
                    .Add(InlineKeyboardButton.WithCallbackData($"{c.TownName}", $"{c.TownName}"));
                    townIndex++;
                    if (townIndex % 4 == 0)
                    {
                        buttonListIndex++;
                        buttonList.Add(new List<InlineKeyboardButton>());
                    }
                }
                InlineKeyboardMarkup replyTowns = new InlineKeyboardMarkup(buttonList);
                return replyTowns;
            }
        }
        public InlineKeyboardMarkup ButtonFuelCreate()
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var cars = db.Fuels.Select(p => new
                {
                   p.Id,
                   p.FuelType,
                   p.Coefficient
                }).ToList();

                var buttonList = new List<List<InlineKeyboardButton>>
                        {
                            new List <InlineKeyboardButton>()
                        };
                int fuelIndex = 0;
                int buttonListIndex = 0;
                foreach (var c in cars)
                {
                    buttonList[buttonListIndex]
                    .Add(InlineKeyboardButton.WithCallbackData($"{c.FuelType}", $"{c.FuelType}"));
                    fuelIndex++;
                    if (fuelIndex % 4 == 0)
                    {
                        buttonListIndex++;
                        buttonList.Add(new List<InlineKeyboardButton>());
                    }
                }
                InlineKeyboardMarkup replyFuel = new InlineKeyboardMarkup(buttonList);
                return replyFuel;
            }
        }
    }
}
