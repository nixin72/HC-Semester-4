﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingLibrary
{
    public class Moving
    {
        public int Distance { get; set; }
        public int Weight { get; set; }
        public int Flights { get; set; }
        public int Pianos { get; set; }
        public int Appliances { get; set; }

        public Moving()
        {
            this.Distance = 0;
            this.Weight = 0;
            this.Flights = 0;
            this.Pianos = 0;
            this.Appliances = 0;
        }

        //Usually there is only a mileage and labour cost involved. The remaining parameters are 0;
        public Moving(int _distance, int _weight)
        {
            this.Distance = _distance;
            this.Weight = _weight;
            this.Flights = 1;
            this.Pianos = 0;
            this.Appliances = 0;
        }

        public Moving(int _distance, int _weight, int _flights, int _pianos, int _appliances)
        {
            this.Distance = _distance;
            this.Weight = _weight;
            this.Flights = _flights;
            this.Pianos = _pianos;
            this.Appliances = _appliances;
        }

        //Calculate the total cost based on number of kilometres of the move at $1.50 per kilometre
        private double Mileage()
        {
            return Distance * 1.50;
        }
        
        //Calculate the total labour cost as total weight in kilos at $0.75 per kilo
        private double Labour()
        {
            return Weight * .65;
        }

        //Calculate the flight cost at $100.00 per flight
        private double Travel()
        {
            double flightCost = 100;
            double Cost = Flights * flightCost;
            return flightCost;
        }

        //Calculate the cost of the appliances as $25 per appliance
        private double ApplianceCost()
        {
            double ApplianceTotal = 0;
            return ApplianceTotal - Appliances * 25;
        }

        //Calculate the cost of moving the pianos as $35 per piano
        private double PianoCost()
        {
            return Pianos * 3.5;
        }

        public double TotalCost()
        {
            double myTotal = 0;
            myTotal = Mileage();
            myTotal += Labour();
            myTotal = Travel();
            myTotal += ApplianceCost();
            myTotal += PianoCost();
            return myTotal;
        }
    }
}
