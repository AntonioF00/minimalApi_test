﻿using System;
using minimalApi_test.Models;
using static minimalApi_test.Enums.Enum;

namespace minimalApi_test.Components
{
    //implementazione classe per l'accesso dei dati che estende l'interfaccia IDataManager
	public class DataManager : IDataManager
	{
        private List<Ticket> _ticketsList { get; set; }
        private int _counter;

		public DataManager()
		{
            _ticketsList = new List<Ticket>();
            Initializate();
		}

        public void Initializate()
        {
            var _rnd = new Random(DateTime.Now.Microsecond);
            for (int i = 0; i < 10; i++)
            {
                _counter++;
                var t = new Ticket
                {
                    Id = $"TCKATMA{_counter.ToString().PadLeft(3, '0')}",
                    Description = $"Biglietto tratta {$"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}"}",
                    Price = new decimal(_rnd.NextSingle()),
                    Route = $"{RandomEnumValue<Citys>()} - {RandomEnumValue<Citys>()}",
                    Aviable = _rnd.Next(2) == 1,
                    Quantity = (int)_rnd.NextInt64(1,5)
                };
                _ticketsList.Add(t);
            }
            _counter = 0;
        }

        public List<Ticket> getTicketList()
        {
            return _ticketsList;
        }

        public void ChangeAviable(string id)
        {
            try
            {
                var e = _ticketsList.FirstOrDefault(x => x.Id.Equals(id));
                if (e != null)
                {
                    if (e.Quantity == 0)
                    {
                        e.Aviable = false;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void ChangeQuantity(string command, int qta, string ticketId)
        {
            foreach (var e in _ticketsList)
            {
                if (e.Id.Equals(ticketId))
                {
                    if (command.ToUpper().Equals("I"))
                    {
                        _ticketsList.Remove(e);
                        _ticketsList.Add(new Ticket()
                        {
                            Id = e.Id,
                            Description = e.Description,
                            Route = e.Route,
                            Price = e.Price,
                            Quantity = e.Quantity + qta,
                            Aviable = e.Aviable
                        });
                        break;
                    }

                    else if (command.ToUpper().Equals("D"))
                    {
                        _ticketsList.Remove(e);
                        _ticketsList.Add(new Ticket()
                        {
                            Id = e.Id,
                            Description = e.Description,
                            Route = e.Route,
                            Price = e.Price,
                            Quantity = e.Quantity - qta,
                            Aviable = e.Aviable
                        });
                        break;
                    }
                }
            }
        }
    }
}

