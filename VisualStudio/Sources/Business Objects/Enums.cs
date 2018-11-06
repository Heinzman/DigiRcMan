namespace Elreg.BusinessObjects
{
    public enum GhostCarLaneChangeFrequency
    {
        Never,
        Seldom,
        Medium,
        Often,
        AsRecorded
    }

    public enum Ghost
    {
        GhostA,
        GhostB
    }

    public enum Specialsound
    {
        None = 0,
        DriverName = 1,
        LapCount = 2,
        Position = 4,
        FinalPosition = 5,
        DriverNameWithPositionIfChanged = 7,
        Penalty = 9,
        PenaltyFor = 10,
        InvalidLap = 23,
        Disqualified = 25,
        Finished = 26,
        FinishApplause = 27
    }

    public enum ActionSoundType
    {
        Lap,
        Disqualified,
        LapDetectedNotAdded,
        Finished,
        Penalty
    }

    public enum SerialPortStatus
    {
        Undefined,
        Connecting,
        Closed,
        OpenWithData,
        OpenWithoutData,
        Disabled
    }

    public enum SerialPortReaderStatus
    {
        Stopped,
        Connecting,
        Started,
        Disabled
    }

    public enum RecorderStatus
    {
        Idle,
        WaitingForStartLine,
        Recording
    }

    public enum ControllerLevel
    {
        L0 = 0,
        L1 = 1,
        L2 = 2,
        L3 = 3,
        L4 = 4,
        L5 = 5,
        L6 = 6,
        L7 = 7,
        L8 = 8,
        L9 = 9,
        L10 = 10,
        L11 = 11,
        L12 = 12,
        L13 = 13,
        L14 = 14,
        L15 = 15
    }

    public enum SsdButtons
    {
        None,
        A,
        B,
        AAndB
    }

    public enum RaceEvent
    {
        Undefined,
        RaceStarted,
        RaceStopped, // 2
        RaceFinished,
        RacePaused,
        LapAdded, // 5
        InvalidLapDueMinLapTime,
        LaneFinished,
        PenaltyAdded, // 10
        LaneDisqualified, //12
        RaceRestarted,
        RestartCountDown,
        StartCountDown
    }

}
