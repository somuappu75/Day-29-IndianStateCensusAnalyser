using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;

namespace StateCensusTest
{
    [TestClass]
    public class UnitTest1
    {
        internal const string FilePath = @"D:\VisualStudio\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\StateCensusData.csv";

         /// <summary>
        /// Test Case 1.1 : Check to ensure no of records matches
        /// </summary>
        [TestMethod]
        public void MatchNumberOfRecords()
        {
            int expected = 29;
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(FilePath);
            stateCensusAnalyser.ReadRecords();
            int actual = stateCensusAnalyser.GetNumberOfRecords();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Case 1.2 : given  .csv file path if incorrect , Returns a Custom Eception
        /// </summary>
        [TestMethod]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"D:\VisualStudio\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusData.csv");
            ExceptionFileNotFound actual = Assert.ThrowsException<ExceptionFileNotFound>(() => stateCensusAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }

        /// <summary>
        /// Test Case 1.3 : given wrong csv file type , read records should throw exception
        /// </summary>
        [TestMethod]
        public void GivenCsvFilePath_WhenTypeImproper_ShouldThrowException()
        {
            string expected = "file type is incorrect";
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"D:\VisualStudio\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\StateCensusData.txt");
            ExceptionWrongFile actual = Assert.ThrowsException<ExceptionWrongFile>(() => stateCensusAnalyser.ReadRecords());
            Assert.AreEqual(expected, actual.Message);
        }
        //Text Case 1.4:Csv file when correct but delimiter incorrect returns exception
        [TestMethod]
        public void GivenCsvFilePath_WhenTypeDelimeterImproper_ShouldThrowException()
        {
            string expected = "File has different delimeter than given";
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"D:\VisualStudio\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\StateCensusData.csv");
            ExceptionIncorrectDelimeter actual = Assert.ThrowsException<ExceptionIncorrectDelimeter>(() => stateCensusAnalyser.ReadRecords(null, '.'));
            Assert.AreEqual(expected, actual.Message);
        }
        // Test Case 1.5 : given csv file Correct , But Incorrect header returns exception

        [TestMethod]
        public void GivenCsvHeaders_WhenImproper_ShouldThrowException()
        {
            string expected = "Headers of file are not valid";
            string[] header = { "SrNo", "State", "Name", "TIN", "Statecode" };
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"D:\VisualStudio\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\StateCensusData.csv");
            ExceptionInvalidHeaders actual = Assert.ThrowsException<ExceptionInvalidHeaders>(() => stateCensusAnalyser.ReadRecords(header, ','));
            Assert.AreEqual(expected, actual.Message);
        }
    }
}
