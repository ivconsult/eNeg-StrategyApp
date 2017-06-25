
#region → Usings   .
using System;
using citPOINT.StrategyApp.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

#region → History  .

/* 
 * Date           User            Change
 * *********************************************
 * 1/17/2012 PM  mwahab          • creation
 * **********************************************
 */

# endregion

#region → ToDos    .

/*
 * Date         set by User     Description
 * 
 * 
*/

# endregion

namespace citPOINT.StrategyApp.MVVM.UnitTest
{

   /// <summary>
    /// Class for StrategyAgent_Test 
    /// </summary>
    [TestClass]
    public class StrategyAgent_Test
    {

        #region → Methods        .

        #region → Public         .

        /// <summary>
        /// Tests the agent while beta 0.8 success.
        /// </summary>
        [TestMethod]
        public void TestAgent_WhileBeta_0_8_Success()
        {
            #region → Arrange .
            try
            {


                StrategyAgent strategyAgent
                              = new StrategyAgent(new DateTime(2000, 1, 1),
                                                  new DateTime(2000, 1, 31),
                                                  0,
                                                  90,
                                                  0.8);
            #endregion

                #region → Act     .

                /*
             *  First of all we get t time
             *  
             * alpha(t)=t^(1/beta)
             * 
             * score=alpha*(max-min)+min
             * 
             * * -----------------------------------------
             *  31/01/2000-01/01/2000 = 30 Days [total days range]
             *  
             *  14/01/2000-01/01/2000 = 13 Days [days from start]
             *  
             *  t= 13 / 30            = 0.43 [Precentage of progress] time..
             *  
             * -----------------------------------------
             *  alpha(t   )=t   ^(1/beta)
             *  alpha(0.43)=0.43^(1/0.8 )
             *             =0.3482
             *             
             * -----------------------------------------
             *  score= alpha *(max-min)+min
             *       = 0.3482*(90 -0  )+0
             *       = 31.34
             */

                strategyAgent.RunAgent(new DateTime(2000, 01, 14), 40);

                #endregion

                #region → Assert  .

                Assert.IsTrue(strategyAgent.StrageyScore == 31.34, string.Format("Error In calculation While Beta={0}", 0.8));
            }
            catch (Exception ex)
            {
                Assert.IsNull(ex, string.Format("Error in calculation : {0}", ex.Message));
            }
                #endregion

        }

        /// <summary>
        /// Tests the agent while beta 50 success.
        /// </summary>
        [TestMethod]
        public void TestAgent_WhileBeta_50_Success()
        {
            #region → Arrange .
            try
            {


                StrategyAgent strategyAgent
                              = new StrategyAgent(new DateTime(2000, 1, 1),
                                                  new DateTime(2000, 1, 31),
                                                  0,
                                                  90,
                                                  50);
            #endregion

                #region → Act     .

                /*
             *  First of all we get t time
             *  
             * alpha(t)=t^(1/beta)
             * 
             * score=alpha*(max-min)+min
             * 
             * * -----------------------------------------
             *  31/01/2000-01/01/2000 = 30 Days [total days range]
             *  
             *  14/01/2000-01/01/2000 = 13 Days [days from start]
             *  
             *  t= 13 / 30            = 0.43 [Precentage of progress] time..
             *  
             * -----------------------------------------
             *  alpha(t   )=t   ^(1/beta)
             *  alpha(0.43)=0.43^(1/50 )
             *             =0.9832
             *             
             * -----------------------------------------
             *  score= alpha *(max-min)+min
             *       = 0.9832*(90 -0  )+0
             *       = 88.49
             */

                strategyAgent.RunAgent(new DateTime(2000, 01, 14), 40);

                #endregion

                #region → Assert  .

                Assert.IsTrue(strategyAgent.StrageyScore == 88.49, string.Format("Error In calculation While Beta={0}", 50));
            }
            catch (Exception ex)
            {
                Assert.IsNull(ex, string.Format("Error in calculation : {0}", ex.Message));
            }
                #endregion

        }

        /// <summary>
        /// Tests the agent while beta 0.2 and change date success.
        /// </summary>
        [TestMethod]
        public void TestAgent_WhileBeta_0_2_And_Change_Date_Success()
        {
            #region → Arrange .
            try
            {


                StrategyAgent strategyAgent
                              = new StrategyAgent(new DateTime(2000, 1, 1),
                                                  new DateTime(2002, 4, 30),
                                                  0,
                                                  90,
                                                  0.2);
            #endregion

                #region → Act     .

                /*
             *  First of all we get t time
             *  
             * alpha(t)=t^(1/beta)
             * 
             * score=alpha*(max-min)+min
             * 
             * * -----------------------------------------
             *  30/04/2002-01/01/2000 = 850 Days [total days range]
             *  
             *  01/09/2001-01/01/2000 = 609 Days [days from start]
             *  
             *  t= 609 / 850            = 0.72 [Precentage of progress] time..
             *  
             * -----------------------------------------
             *  alpha(t   )=t   ^(1/beta)
             *  alpha(0.72)=0.72^(1/0.2 )
             *             =0.1934
             *             
             * -----------------------------------------
             *  score= alpha *(max-min)+min
             *       = 0.1934*(90 -0  )+0
             *       = 17.41
             */

                strategyAgent.RunAgent(new DateTime(2001, 09, 01), 40);

                #endregion

                #region → Assert  .

                Assert.IsTrue(strategyAgent.StrageyScore == 17.41, string.Format("Error In calculation While Beta={0}", 50));
            }
            catch (Exception ex)
            {
                Assert.IsNull(ex, string.Format("Error in calculation : {0}", ex.Message));
            }
                #endregion

        }


        #endregion  Public

        #endregion Methods

    }
}
