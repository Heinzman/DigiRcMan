using System.Windows.Media.Imaging;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.WpfViewModel
{
    public class LaneStatusCalculator
    {
        private readonly ResourceProxy _resourceProxy = new ResourceProxy();

        public BitmapImage CalcLaneStatus(Lane lane)
        {
            BitmapImage image = null;
            int penaltyCount = lane.PenaltyQueue.Count;

            if (lane.Status == Lane.LaneStatusEnum.Disqualified)
            {
                image = _resourceProxy.GetBitmap("Disqualified1");
            }
            else if (lane.Status == Lane.LaneStatusEnum.Finished)
            {
                image = _resourceProxy.GetBitmap("Finished");
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.Out)
            {
                if (penaltyCount > 0)
                {
                    #region Has Penalties

                    Penalty currentPenalty = lane.PenaltyQueue.Peek();
                    int lapsLeftToStop = currentPenalty.LapsLeftToStop;

                    if (penaltyCount == 1)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("Penalty1_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("Penalty1_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("Penalty1_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("Penalty1_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("Penalty1_X");
                        }
                    }
                    else if (penaltyCount == 2)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("Penalty2_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("Penalty2_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("Penalty2_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("Penalty2_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("Penalty2_X");
                        }
                    }
                    else if (penaltyCount == 3)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("Penalty3_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("Penalty3_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("Penalty3_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("Penalty3_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("Penalty3_X");
                        }
                    }
                    else if (penaltyCount == 4)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("Penalty4_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("Penalty4_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("Penalty4_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("Penalty4_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("Penalty4_X");
                        }
                    }
                    else if (penaltyCount == 5)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("Penalty5_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("Penalty5_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("Penalty5_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("Penalty5_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("Penalty5_X");
                        }
                    }
                    else if (penaltyCount > 5)
                    {
                        if (lapsLeftToStop >= 4)
                        {
                            image = _resourceProxy.GetBitmap("PenaltyX_3");
                        }
                        else if (lapsLeftToStop == 3)
                        {
                            image = _resourceProxy.GetBitmap("PenaltyX_2");
                        }
                        else if (lapsLeftToStop == 2)
                        {
                            image = _resourceProxy.GetBitmap("PenaltyX_1");
                        }
                        else if (lapsLeftToStop == 1)
                        {
                            image = _resourceProxy.GetBitmap("PenaltyX_0");
                        }
                        else if (lapsLeftToStop == 0)
                        {
                            image = _resourceProxy.GetBitmap("PenaltyX_X");
                        }
                    }

                    #endregion
                }
                else if (lane.CurrentFuelLevelInLitres <= 0)
                {
                    image = _resourceProxy.GetBitmap("FuelEmpty");
                }
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.PenaltyWaiting)
            {
                if (penaltyCount == 1)
                {
                    image = _resourceProxy.GetBitmap("wait1");
                }
                else if (penaltyCount == 2)
                {
                    image = _resourceProxy.GetBitmap("wait2");
                }
                else if (penaltyCount == 3)
                {
                    image = _resourceProxy.GetBitmap("wait3");
                }
                else if (penaltyCount == 4)
                {
                    image = _resourceProxy.GetBitmap("wait4");
                }
                else if (penaltyCount == 5)
                {
                    image = _resourceProxy.GetBitmap("wait5");
                }
                else if (penaltyCount > 5)
                {
                    image = _resourceProxy.GetBitmap("waitX");
                }
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.Refueling)
            {
                image = _resourceProxy.GetBitmap("Refueling");
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.RefuelingWaiting)
            {
                image = _resourceProxy.GetBitmap("RefuelingWaiting");
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.FixingEngineWaiting ||
                     lane.PitstopStatus == Lane.PitstopStatusEnum.FixingDamageByRocketWaiting)
            {
                image = _resourceProxy.GetBitmap("Screwdriver");
            }
            else if (lane.PitstopStatus == Lane.PitstopStatusEnum.PenaltyDone ||
                     lane.PitstopStatus == Lane.PitstopStatusEnum.RefuelingDone ||
                     lane.PitstopStatus == Lane.PitstopStatusEnum.FixingEngineDone ||
                     lane.PitstopStatus == Lane.PitstopStatusEnum.FixingDamageByRocketDone)
            {
                image = _resourceProxy.GetBitmap("Go");
            }

            return image;
        }


    }
}
