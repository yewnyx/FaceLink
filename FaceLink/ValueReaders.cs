using System.Globalization;
using OscCore;

namespace xyz.yewnyx.FaceLink; 

public class  ValueReaders {
    public float[] EyeTrackData = new float[3];
    public float[] Eyelids = new float[2];
    public UnifiedExpressionsValues Values;

    public void EyeTrackedGazePointValueRead(OscMessageValues mv) {
        var one = float.Parse(mv.ReadStringElement(0), CultureInfo.InvariantCulture.NumberFormat);
        var two = float.Parse(mv.ReadStringElement(1), CultureInfo.InvariantCulture.NumberFormat);
        var three = float.Parse(mv.ReadStringElement(2), CultureInfo.InvariantCulture.NumberFormat);
        EyeTrackData[0] = one;
        EyeTrackData[1] = two;
        EyeTrackData[2] = three;
    }

    public void EyesClosedLValueRead(OscMessageValues mv) {
        var value = float.Parse(mv.ReadStringElement(0), CultureInfo.InvariantCulture.NumberFormat);
        Eyelids[0] = value;
    }

    public void EyesClosedRValueRead(OscMessageValues mv) {
        var value = float.Parse(mv.ReadStringElement(0), CultureInfo.InvariantCulture.NumberFormat);
        Eyelids[1] = value;
    }

    public void ConfidenceUpperFaceValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.Confidence.UpperFace = value;
    }

    public void ConfidenceLowerFaceValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.Confidence.LowerFace = value;
    }

    public void UpperLidRaiserLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.EyeWideLeft = value;
    }

    public void UpperLidRaiserRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.EyeWideRight = value;
    }
    public void LidTightenerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.EyeSquintLeft = value;
    }
    public void LidTightenerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.EyeSquintRight = value;
    }
    public void InnerBrowRaiserLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowInnerUpLeft = value;
    }
    public void InnerBrowRaiserRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowInnerUpRight = value;
    }
    public void OuterBrowRaiserLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowOuterUpLeft = value;
    }
    public void OuterBrowRaiserRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowOuterUpRight = value;
    }
    public void BrowLowererLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowPinchLeft = value;
        Values.BrowLowererLeft = value;
    }
    public void BrowLowererRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.BrowPinchRight = value;
        Values.BrowLowererRight = value;
    }

    public void JawDropValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.JawOpen = value;
    }
    public void JawSidewaysLeftValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.JawLeft = value;
    }
    public void JawSidewaysRightValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.JawRight = value;
    }
    public void JawThrustValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.JawForward = value;
    }

    public void MouthLeftValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthLowerLeft = value;
        Values.MouthUpperLeft = value;
    }
    public void MouthRightValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthLowerRight = value;
        Values.MouthUpperRight = value;
    }

    public void ChinRaiserTValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthRaiserUpper = value;
    }
    public void ChinRaiserBValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthRaiserLower = value;
    }

    public void DimplerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthDimpleLeft = value;
    }
    public void DimplerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthDimpleRight = value;
    }

    public void LipsTowardValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthClosed = value;
    }
    public void LipCornerPullerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthCornerPullLeft = value;
        Values.MouthCornerSlantLeft = value;
    }
    public void LipCornerPullerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthCornerPullRight = value;
        Values.MouthCornerSlantRight = value;
    }
    public void LipCornerDepressorLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthFrownLeft = value;
    }
    public void LipCornerDepressorRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthFrownRight = value;
    }
    public void LowerLipDepressorLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthLowerDownLeft = value;
    }
    public void LowerLipDepressorRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthLowerDownRight = value;
    }
    public void UpperLipRaiserLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthUpperUpLeft = value;
    }
    public void UpperLipRaiserRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthUpperUpRight = value;
    }
    public void LipTightenerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthTightenerLeft = value;
    }
    public void LipTightenerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthTightenerRight = value;
    }
    public void LipPressorLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthPressLeft = value;
    }
    public void LipPressorRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthPressRight = value;
    }
    public void LipStretcherLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthStretchLeft = value;
    }
    public void LipStretcherRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.MouthStretchRight = value;
    }
    public void LipPuckerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipPuckerLowerLeft = value;
        Values.LipPuckerUpperLeft = value;
    }
    public void LipPuckerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipPuckerLowerRight = value;
        Values.LipPuckerUpperRight = value;
    }
    public void LipFunnelerLBValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipFunnelLowerLeft = value;
    }
    public void LipFunnelerLTValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipFunnelUpperLeft = value;
    }
    public void LipFunnelerRBValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipFunnelLowerRight = value;
    }
    public void LipFunnelerRTValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipFunnelUpperRight = value;
    }
    public void LipSuckLBValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipSuckLowerLeft = value;
    }
    public void LipSuckLTValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipSuckUpperLeft = value;
    }
    public void LipSuckRBValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipSuckLowerRight = value;
    }
    public void LipSuckRTValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.LipSuckUpperRight = value;
    }

    public void CheekPuffLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekPuffLeft = value;
    }
    public void CheekPuffRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekPuffRight = value;
    }
    public void CheekSuckLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekSuckLeft = value;
    }
    public void CheekSuckRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekSuckRight = value;
    }
    public void CheekRaiserLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekSquintLeft = value;
    }
    public void CheekRaiserRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.CheekSquintRight = value;
    }

    public void NoseWrinklerLValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.NoseSneerLeft = value;
    }
    public void NoseWrinklerRValueRead(OscMessageValues mv) {
        var value = mv.ReadFloatElement(0);
        Values.NoseSneerRight = value;
    }
}

