using System.Collections.Immutable;
using static xyz.yewnyx.FaceLink.Constants.UnifiedExpressionsNames;
using static xyz.yewnyx.FaceLink.Constants.XRFBAddresses;

namespace xyz.yewnyx.FaceLink; 

public static partial class Constants {
    public static class Addresses {
        public const string EyeTrackedGazePoint = "/sl/eyeTrackedGazePoint";
    }
    public static class XRFBAddresses {
        public static class Confidence {
            public const string UpperFace = "/sl/xrfb/facec/UpperFace";
            public const string LowerFace = "/sl/xrfb/facec/LowerFace";
        }

        public const string BrowLowererL = "/sl/xrfb/facew/BrowLowererL";
        public const string BrowLowererR = "/sl/xrfb/facew/BrowLowererR";
        public const string CheekPuffL = "/sl/xrfb/facew/CheekPuffL";
        public const string CheekPuffR = "/sl/xrfb/facew/CheekPuffR";
        public const string CheekRaiserL = "/sl/xrfb/facew/CheekRaiserL";
        public const string CheekRaiserR = "/sl/xrfb/facew/CheekRaiserR";
        public const string CheekSuckL = "/sl/xrfb/facew/CheekSuckL";
        public const string CheekSuckR = "/sl/xrfb/facew/CheekSuckR";
        public const string ChinRaiserB = "/sl/xrfb/facew/ChinRaiserB";
        public const string ChinRaiserT = "/sl/xrfb/facew/ChinRaiserT";
        public const string DimplerL = "/sl/xrfb/facew/DimplerL";
        public const string DimplerR = "/sl/xrfb/facew/DimplerR";
        public const string EyesClosedL = "/sl/xrfb/facew/EyesClosedL";
        public const string EyesClosedR = "/sl/xrfb/facew/EyesClosedR";
        public const string EyesLookDownL = "/sl/xrfb/facew/EyesLookDownL";
        public const string EyesLookDownR = "/sl/xrfb/facew/EyesLookDownR";
        public const string EyesLookLeftL = "/sl/xrfb/facew/EyesLookLeftL";
        public const string EyesLookLeftR = "/sl/xrfb/facew/EyesLookLeftR";
        public const string EyesLookRightL = "/sl/xrfb/facew/EyesLookRightL";
        public const string EyesLookRightR = "/sl/xrfb/facew/EyesLookRightR";
        public const string EyesLookUpL = "/sl/xrfb/facew/EyesLookUpL";
        public const string EyesLookUpR = "/sl/xrfb/facew/EyesLookUpR";
        public const string InnerBrowRaiserL = "/sl/xrfb/facew/InnerBrowRaiserL";
        public const string InnerBrowRaiserR = "/sl/xrfb/facew/InnerBrowRaiserR";
        public const string JawDrop = "/sl/xrfb/facew/JawDrop";
        public const string JawSidewaysLeft = "/sl/xrfb/facew/JawSidewaysLeft";
        public const string JawSidewaysRight = "/sl/xrfb/facew/JawSidewaysRight";
        public const string JawThrust = "/sl/xrfb/facew/JawThrust";
        public const string LidTightenerL = "/sl/xrfb/facew/LidTightenerL";
        public const string LidTightenerR = "/sl/xrfb/facew/LidTightenerR";
        public const string LipCornerDepressorL = "/sl/xrfb/facew/LipCornerDepressorL";
        public const string LipCornerDepressorR = "/sl/xrfb/facew/LipCornerDepressorR";
        public const string LipCornerPullerL = "/sl/xrfb/facew/LipCornerPullerL";
        public const string LipCornerPullerR = "/sl/xrfb/facew/LipCornerPullerR";
        public const string LipFunnelerLB = "/sl/xrfb/facew/LipFunnelerLB";
        public const string LipFunnelerLT = "/sl/xrfb/facew/LipFunnelerLT";
        public const string LipFunnelerRB = "/sl/xrfb/facew/LipFunnelerRB";
        public const string LipFunnelerRT = "/sl/xrfb/facew/LipFunnelerRT";
        public const string LipPressorL = "/sl/xrfb/facew/LipPressorL";
        public const string LipPressorR = "/sl/xrfb/facew/LipPressorR";
        public const string LipPuckerL = "/sl/xrfb/facew/LipPuckerL";
        public const string LipPuckerR = "/sl/xrfb/facew/LipPuckerR";
        public const string LipStretcherL = "/sl/xrfb/facew/LipStretcherL";
        public const string LipStretcherR = "/sl/xrfb/facew/LipStretcherR";
        public const string LipSuckLB = "/sl/xrfb/facew/LipSuckLB";
        public const string LipSuckLT = "/sl/xrfb/facew/LipSuckLT";
        public const string LipSuckRB = "/sl/xrfb/facew/LipSuckRB";
        public const string LipSuckRT = "/sl/xrfb/facew/LipSuckRT";
        public const string LipTightenerL = "/sl/xrfb/facew/LipTightenerL";
        public const string LipTightenerR = "/sl/xrfb/facew/LipTightenerR";
        public const string LipsToward = "/sl/xrfb/facew/LipsToward";
        public const string LowerLipDepressorL = "/sl/xrfb/facew/LowerLipDepressorL";
        public const string LowerLipDepressorR = "/sl/xrfb/facew/LowerLipDepressorR";
        public const string MouthLeft = "/sl/xrfb/facew/MouthLeft";
        public const string MouthRight = "/sl/xrfb/facew/MouthRight";
        public const string NoseWrinklerL = "/sl/xrfb/facew/NoseWrinklerL";
        public const string NoseWrinklerR = "/sl/xrfb/facew/NoseWrinklerR";
        public const string OuterBrowRaiserL = "/sl/xrfb/facew/OuterBrowRaiserL";
        public const string OuterBrowRaiserR = "/sl/xrfb/facew/OuterBrowRaiserR";
        public const string UpperLidRaiserL = "/sl/xrfb/facew/UpperLidRaiserL";
        public const string UpperLidRaiserR = "/sl/xrfb/facew/UpperLidRaiserR";
        public const string UpperLipRaiserL = "/sl/xrfb/facew/UpperLipRaiserL";
        public const string UpperLipRaiserR = "/sl/xrfb/facew/UpperLipRaiserR";
    }
    
    public static class UnifiedExpressionsNames {
        public const string EyeLookInRight = nameof(EyeLookInRight);
        public const string EyeLookUpRight = nameof(EyeLookUpRight);
        public const string EyeLookDownRight = nameof(EyeLookDownRight);
        public const string EyeLookOutLeft = nameof(EyeLookOutLeft);
        public const string EyeLookInLeft = nameof(EyeLookInLeft);
        public const string EyeLookUpLeft = nameof(EyeLookUpLeft);
        public const string EyeLookDownLeft = nameof(EyeLookDownLeft);
        public const string EyeClosedRight = nameof(EyeClosedRight);
        public const string EyeClosedLeft = nameof(EyeClosedLeft);
        public const string EyeSquintRight = nameof(EyeSquintRight);
        public const string EyeSquintLeft = nameof(EyeSquintLeft);
        public const string EyeWideRight = nameof(EyeWideRight);
        public const string EyeWideLeft = nameof(EyeWideLeft);
        public const string EyeDilationRight = nameof(EyeDilationRight);
        public const string EyeDilationLeft = nameof(EyeDilationLeft);
        public const string EyeConstrictRight = nameof(EyeConstrictRight);
        public const string EyeConstrictLeft = nameof(EyeConstrictLeft);
        public const string BrowPinchRight = nameof(BrowPinchRight);
        public const string BrowPinchLeft = nameof(BrowPinchLeft);
        public const string BrowLowererRight = nameof(BrowLowererRight);
        public const string BrowLowererLeft = nameof(BrowLowererLeft);
        public const string BrowInnerUpRight = nameof(BrowInnerUpRight);
        public const string BrowInnerUpLeft = nameof(BrowInnerUpLeft);
        public const string BrowOuterUpRight = nameof(BrowOuterUpRight);
        public const string BrowOuterUpLeft = nameof(BrowOuterUpLeft);
        public const string NoseSneerRight = nameof(NoseSneerRight);
        public const string NoseSneerLeft = nameof(NoseSneerLeft);
        public const string NasalDilationRight = nameof(NasalDilationRight);
        public const string NasalDilationLeft = nameof(NasalDilationLeft);
        public const string NasalConstrictRight = nameof(NasalConstrictRight);
        public const string NasalConstrictLeft = nameof(NasalConstrictLeft);
        public const string CheekSquintRight = nameof(CheekSquintRight);
        public const string CheekSquintLeft = nameof(CheekSquintLeft);
        public const string CheekPuffRight = nameof(CheekPuffRight);
        public const string CheekPuffLeft = nameof(CheekPuffLeft);
        public const string CheekSuckRight = nameof(CheekSuckRight);
        public const string CheekSuckLeft = nameof(CheekSuckLeft);
        public const string JawOpen = nameof(JawOpen);
        public const string MouthClosed = nameof(MouthClosed);
        public const string JawRight = nameof(JawRight);
        public const string JawLeft = nameof(JawLeft);
        public const string JawForward = nameof(JawForward);
        public const string JawBackward = nameof(JawBackward);
        public const string JawClench = nameof(JawClench);
        public const string JawMandibleRaise = nameof(JawMandibleRaise);
        public const string LipSuckUpperRight = nameof(LipSuckUpperRight);
        public const string LipSuckUpperLeft = nameof(LipSuckUpperLeft);
        public const string LipSuckLowerRight = nameof(LipSuckLowerRight);
        public const string LipSuckLowerLeft = nameof(LipSuckLowerLeft);
        public const string LipSuckCornerRight = nameof(LipSuckCornerRight);
        public const string LipSuckCornerLeft = nameof(LipSuckCornerLeft);
        public const string LipFunnelUpperRight = nameof(LipFunnelUpperRight);
        public const string LipFunnelUpperLeft = nameof(LipFunnelUpperLeft);
        public const string LipFunnelLowerRight = nameof(LipFunnelLowerRight);
        public const string LipFunnelLowerLeft = nameof(LipFunnelLowerLeft);
        public const string LipPuckerUpperRight = nameof(LipPuckerUpperRight);
        public const string LipPuckerUpperLeft = nameof(LipPuckerUpperLeft);
        public const string LipPuckerLowerRight = nameof(LipPuckerLowerRight);
        public const string LipPuckerLowerLeft = nameof(LipPuckerLowerLeft);
        public const string MouthUpperUpRight = nameof(MouthUpperUpRight);
        public const string MouthUpperUpLeft = nameof(MouthUpperUpLeft);
        public const string MouthLowerDownRight = nameof(MouthLowerDownRight);
        public const string MouthLowerDownLeft = nameof(MouthLowerDownLeft);
        public const string MouthUpperDeepenRight = nameof(MouthUpperDeepenRight);
        public const string MouthUpperDeepenLeft = nameof(MouthUpperDeepenLeft);
        public const string MouthUpperRight = nameof(MouthUpperRight);
        public const string MouthUpperLeft = nameof(MouthUpperLeft);
        public const string MouthLowerRight = nameof(MouthLowerRight);
        public const string MouthLowerLeft = nameof(MouthLowerLeft);
        public const string MouthCornerPullRight = nameof(MouthCornerPullRight);
        public const string MouthCornerPullLeft = nameof(MouthCornerPullLeft);
        public const string MouthCornerSlantRight = nameof(MouthCornerSlantRight);
        public const string MouthCornerSlantLeft = nameof(MouthCornerSlantLeft);
        public const string MouthFrownRight = nameof(MouthFrownRight);
        public const string MouthFrownLeft = nameof(MouthFrownLeft);
        public const string MouthStretchRight = nameof(MouthStretchRight);
        public const string MouthStretchLeft = nameof(MouthStretchLeft);
        public const string MouthDimpleRight = nameof(MouthDimpleRight);
        public const string MouthDimpleLeft = nameof(MouthDimpleLeft);
        public const string MouthRaiserUpper = nameof(MouthRaiserUpper);
        public const string MouthRaiserLower = nameof(MouthRaiserLower);
        public const string MouthPressRight = nameof(MouthPressRight);
        public const string MouthPressLeft = nameof(MouthPressLeft);
        public const string MouthTightenerRight = nameof(MouthTightenerRight);
        public const string MouthTightenerLeft = nameof(MouthTightenerLeft);
        public const string TongueOut = nameof(TongueOut);
        public const string TongueUp = nameof(TongueUp);
        public const string TongueDown = nameof(TongueDown);
        public const string TongueRight = nameof(TongueRight);
        public const string TongueLeft = nameof(TongueLeft);
        public const string TongueRoll = nameof(TongueRoll);
        public const string TongueBendDown = nameof(TongueBendDown);
        public const string TongueCurlUp = nameof(TongueCurlUp);
        public const string TongueSquish = nameof(TongueSquish);
        public const string TongueFlat = nameof(TongueFlat);
        public const string TongueTwistRight = nameof(TongueTwistRight);
        public const string TongueTwistLeft = nameof(TongueTwistLeft);
        public const string SoftPalateClose = nameof(SoftPalateClose);
        public const string ThroatSwallow = nameof(ThroatSwallow);
        public const string NeckFlexRight = nameof(NeckFlexRight);
        public const string NeckFlexLeft = nameof(NeckFlexLeft);
    }
    
    public static readonly ImmutableDictionary<string, string[]> XRFBAddressToUnifiedExpressionsNames = new Dictionary<string, string[]> {
        {UpperLidRaiserL, new[] {EyeWideLeft}},
        {UpperLidRaiserR, new[] {EyeWideRight}},
        {LidTightenerL, new[] {EyeSquintLeft}},
        {LidTightenerR, new[] {EyeSquintRight}},
        {InnerBrowRaiserL, new[] {BrowInnerUpLeft}},
        {InnerBrowRaiserR, new[] {BrowInnerUpRight}},
        {OuterBrowRaiserL, new[] {BrowOuterUpLeft}},
        {OuterBrowRaiserR, new[] {BrowOuterUpRight}},
        {BrowLowererL, new[] {BrowPinchLeft, BrowLowererLeft}},
        {BrowLowererR, new[] {BrowPinchRight, BrowLowererRight}},

        {JawDrop, new[] {JawOpen}},
        {JawSidewaysLeft, new[] {JawLeft}},
        {JawSidewaysRight, new[] {JawRight}},
        {JawThrust, new[] {JawForward}},

        {MouthLeft, new[] {MouthLowerLeft, MouthUpperLeft}},
        {MouthRight, new[] {MouthLowerRight, MouthUpperRight}},

        {ChinRaiserT, new[] {MouthRaiserUpper}},
        {ChinRaiserB, new[] {MouthRaiserLower}},

        {DimplerL, new[] {MouthDimpleLeft}},
        {DimplerR, new[] {MouthDimpleRight}},

        {LipsToward, new[] {MouthClosed}},
        {LipCornerPullerL, new[] {MouthCornerPullLeft, MouthCornerSlantLeft}},
        {LipCornerPullerR, new[] {MouthCornerPullRight, MouthCornerSlantRight}},
        {LipCornerDepressorL, new[] {MouthFrownLeft}},
        {LipCornerDepressorR, new[] {MouthFrownRight}},
        {LowerLipDepressorL, new[] {MouthLowerDownLeft}},
        {LowerLipDepressorR, new[] {MouthLowerDownRight}},
        {UpperLipRaiserL, new[] {MouthUpperUpLeft}},
        {UpperLipRaiserR, new[] {MouthUpperUpRight}},
        {LipTightenerL, new[] {MouthTightenerLeft}},
        {LipTightenerR, new[] {MouthTightenerRight}},
        {LipPressorL, new[] {MouthPressLeft}},
        {LipPressorR, new[] {MouthPressRight}},
        {LipStretcherL, new[] {MouthStretchLeft}},
        {LipStretcherR, new[] {MouthStretchRight}},
        {LipPuckerL, new[] {LipPuckerLowerLeft, LipPuckerUpperLeft}},
        {LipPuckerR, new[] {LipPuckerLowerRight, LipPuckerUpperRight}},
        {LipFunnelerLB, new[] {LipFunnelLowerLeft}},
        {LipFunnelerLT, new[] {LipFunnelUpperLeft}},
        {LipFunnelerRB, new[] {LipFunnelLowerRight}},
        {LipFunnelerRT, new[] {LipFunnelUpperRight}},
        {LipSuckLB, new[] {LipSuckLowerLeft}},
        {LipSuckLT, new[] {LipSuckUpperLeft}},
        {LipSuckRB, new[] {LipSuckLowerRight}},
        {LipSuckRT, new[] {LipSuckUpperRight}},

        {CheekPuffL, new[] {CheekPuffLeft}},
        {CheekPuffR, new[] {CheekPuffRight}},
        {CheekSuckL, new[] {CheekSuckLeft}},
        {CheekSuckR, new[] {CheekSuckRight}},
        {CheekRaiserL, new[] {CheekSquintLeft}},
        {CheekRaiserR, new[] {CheekSquintRight}},

        {NoseWrinklerL, new[] {NoseSneerLeft}},
        {NoseWrinklerR, new[] {NoseSneerRight}},
    }.ToImmutableDictionary();
}