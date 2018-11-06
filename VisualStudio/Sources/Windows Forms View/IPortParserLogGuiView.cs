namespace Elreg.WindowsFormsView
{
    public interface IPortParserLogGuiView : ISimpleView
    {
        uint Speed1 { set; }
        uint Speed2 { set; }
        uint Speed3 { set; }
        uint Speed4 { set; }
        uint Speed5 { set; }
        uint Speed6 { set; }
        bool LaneChange1 { set; }
        bool LaneChange2 { set; }
        bool LaneChange3 { set; }
        bool LaneChange4 { set; }
        bool LaneChange5 { set; }
        bool LaneChange6 { set; }
        void AddLap1();
        void AddLap2();
        void AddLap3();
        void AddLap4();
        void AddLap5();
        void AddLap6();
    }
}
