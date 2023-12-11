﻿using System.Net;
using OscCore;
using VRC.OSCQuery;
using static xyz.yewnyx.FaceLink.Constants;

namespace xyz.yewnyx.FaceLink {
    static class Program {
        private static bool VRCReady = false;
        private static IPAddress VRCAddress = IPAddress.Loopback;
        private static int VRCPort = 0;
        private static ValueReaders valueReaders = new();
        
        private static async Task Main(string[] args) {
            const int oscPort = 9015;
            var oscQueryPort = Extensions.GetAvailableTcpPort();

            const string OSCQUERY_SERVICE_NAME = "FaceLink";
            Console.Write($"\nSetting up OSCQuery on UDP:{oscPort} TCP:{oscQueryPort}\n");
            IDiscovery discovery = new MeaModDiscovery();
            var oscQuery = new OSCQueryServiceBuilder()
                .WithServiceName(OSCQUERY_SERVICE_NAME)
                .WithUdpPort(oscPort)
                .WithTcpPort(oscQueryPort)
                .WithDiscovery(discovery)
                .StartHttpServer()
                .AdvertiseOSC()
                .AdvertiseOSCQuery()
                .AddListenerForServiceType(Listener, OSCQueryServiceProfile.ServiceType.OSC)
                .Build();
            oscQuery.RefreshServices();

            var oscServer = new OscServer(oscPort);
            RegisterMethods(oscServer, ref valueReaders);

            oscServer.Start();
            
            while (!VRCReady) {
                oscQuery.RefreshServices();
                Thread.Sleep(10);
            }
            
            var oscClient = new OscClient(VRCAddress.ToString(), VRCPort);
            
            var avatarParameters = new VRChatFTv2AvatarParameters();
            while (VRCReady) {
                UpdateParameters(ref avatarParameters, ref valueReaders);
                SendParameters(oscClient, avatarParameters);
                Thread.Sleep(10);
            }
        }
        
        private static void RegisterMethods(OscServer oscServer, ref ValueReaders vr) {
            oscServer.TryAddMethod(Addresses.EyeTrackedGazePoint, vr.EyeTrackedGazePointValueRead);
            oscServer.TryAddMethod(XRFBAddresses.EyesClosedL, vr.EyesClosedLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.EyesClosedR, vr.EyesClosedRValueRead);

            oscServer.TryAddMethod(XRFBAddresses.Confidence.UpperFace, vr.ConfidenceUpperFaceValueRead);
            oscServer.TryAddMethod(XRFBAddresses.Confidence.LowerFace, vr.ConfidenceLowerFaceValueRead);
            
            oscServer.TryAddMethod(XRFBAddresses.UpperLidRaiserL, vr.UpperLidRaiserLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.UpperLidRaiserR, vr.UpperLidRaiserRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LidTightenerL, vr.LidTightenerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LidTightenerR, vr.LidTightenerRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.InnerBrowRaiserL, vr.InnerBrowRaiserLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.InnerBrowRaiserR, vr.InnerBrowRaiserRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.OuterBrowRaiserL, vr.OuterBrowRaiserLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.OuterBrowRaiserR, vr.OuterBrowRaiserRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.BrowLowererL, vr.BrowLowererLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.BrowLowererR, vr.BrowLowererRValueRead);

            oscServer.TryAddMethod(XRFBAddresses.JawDrop, vr.JawDropValueRead);
            oscServer.TryAddMethod(XRFBAddresses.JawSidewaysLeft, vr.JawSidewaysLeftValueRead);
            oscServer.TryAddMethod(XRFBAddresses.JawSidewaysRight, vr.JawSidewaysRightValueRead);
            oscServer.TryAddMethod(XRFBAddresses.JawThrust, vr.JawThrustValueRead);

            oscServer.TryAddMethod(XRFBAddresses.MouthLeft, vr.MouthLeftValueRead);
            oscServer.TryAddMethod(XRFBAddresses.MouthRight, vr.MouthRightValueRead);

            oscServer.TryAddMethod(XRFBAddresses.ChinRaiserT, vr.ChinRaiserTValueRead);
            oscServer.TryAddMethod(XRFBAddresses.ChinRaiserB, vr.ChinRaiserBValueRead);

            oscServer.TryAddMethod(XRFBAddresses.DimplerL, vr.DimplerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.DimplerR, vr.DimplerRValueRead);

            oscServer.TryAddMethod(XRFBAddresses.LipsToward, vr.LipsTowardValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipCornerPullerL, vr.LipCornerPullerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipCornerPullerR, vr.LipCornerPullerRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipCornerDepressorL, vr.LipCornerDepressorLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipCornerDepressorR, vr.LipCornerDepressorRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LowerLipDepressorL, vr.LowerLipDepressorLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LowerLipDepressorR, vr.LowerLipDepressorRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.UpperLipRaiserL, vr.UpperLipRaiserLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.UpperLipRaiserR, vr.UpperLipRaiserRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipTightenerL, vr.LipTightenerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipTightenerR, vr.LipTightenerRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipPressorL, vr.LipPressorLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipPressorR, vr.LipPressorRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipStretcherL, vr.LipStretcherLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipStretcherR, vr.LipStretcherRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipPuckerL, vr.LipPuckerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipPuckerR, vr.LipPuckerRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipFunnelerLB, vr.LipFunnelerLBValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipFunnelerLT, vr.LipFunnelerLTValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipFunnelerRB, vr.LipFunnelerRBValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipFunnelerRT, vr.LipFunnelerRTValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipSuckLB, vr.LipSuckLBValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipSuckLT, vr.LipSuckLTValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipSuckRB, vr.LipSuckRBValueRead);
            oscServer.TryAddMethod(XRFBAddresses.LipSuckRT, vr.LipSuckRTValueRead);

            oscServer.TryAddMethod(XRFBAddresses.CheekPuffL, vr.CheekPuffLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.CheekPuffR, vr.CheekPuffRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.CheekSuckL, vr.CheekSuckLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.CheekSuckR, vr.CheekSuckRValueRead);
            oscServer.TryAddMethod(XRFBAddresses.CheekRaiserL, vr.CheekRaiserLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.CheekRaiserR, vr.CheekRaiserRValueRead);

            oscServer.TryAddMethod(XRFBAddresses.NoseWrinklerL, vr.NoseWrinklerLValueRead);
            oscServer.TryAddMethod(XRFBAddresses.NoseWrinklerR, vr.NoseWrinklerRValueRead);
        }
        
        private static void UpdateParameters(ref VRChatFTv2AvatarParameters avatarParameters, ref ValueReaders vr) {
            // TODO: Add more parameters and find proper mappings for 1,2,4 variants
            avatarParameters.EyeLidLeft = 1.0f - vr.Eyelids[0];
            avatarParameters.EyeLidRight = 1.0f - vr.Eyelids[1];
            avatarParameters.EyeLeftX = vr.EyeTrackData[0];
            avatarParameters.EyeRightX = vr.EyeTrackData[0];
            avatarParameters.EyeY = vr.EyeTrackData[1];

            avatarParameters.JawOpen = vr.Values.JawOpen;
            avatarParameters.MouthClosed = vr.Values.MouthClosed;
            avatarParameters.MouthUpperUp = (vr.Values.MouthUpperLeft + vr.Values.MouthUpperRight) / 2.0f;
            avatarParameters.MouthLowerDown1 = vr.Values.MouthLowerDownLeft;
            avatarParameters.MouthLowerDown2 = vr.Values.MouthLowerDownRight;
            avatarParameters.MouthLowerDown4 = (vr.Values.MouthLowerDownLeft + vr.Values.MouthLowerDownRight) / 2.0f;
            avatarParameters.SmileFrownLeft1 = vr.Values.MouthFrownLeft;
            avatarParameters.SmileFrownRight1 = vr.Values.MouthFrownRight;
            //avatarParameters.LipPucker1 = (valueReaders.Values.LipPuckerUpperLeft + valueReaders.Values.LipPuckerUpperRight) / 2.0f;
            //avatarParameters.LipPucker2 = (valueReaders.Values.LipPuckerLowerLeft + valueReaders.Values.LipPuckerLowerRight) / 2.0f;
            //avatarParameters.LipPucker4 = 
            avatarParameters.JawX1 = vr.Values.JawLeft;
            avatarParameters.JawX2 = vr.Values.JawRight;
            avatarParameters.JawX4 = (vr.Values.JawLeft + vr.Values.JawRight) / 2.0f;
            avatarParameters.MouthX1 = vr.Values.MouthStretchLeft;
            avatarParameters.MouthX2 = vr.Values.MouthStretchRight;
            avatarParameters.MouthX4 = (vr.Values.MouthStretchLeft + vr.Values.MouthStretchRight) / 2.0f;
            avatarParameters.MouthX8 = (vr.Values.MouthStretchLeft + vr.Values.MouthStretchRight) / 2.0f;
            avatarParameters.MouthXNegative = (vr.Values.MouthStretchLeft + vr.Values.MouthStretchRight) / 2.0f;
            avatarParameters.CheekPuffLeft1 = vr.Values.CheekPuffLeft;
            avatarParameters.CheekPuffLeft2 = vr.Values.CheekPuffRight;
            avatarParameters.CheekPuffLeft4 = (vr.Values.CheekPuffLeft + vr.Values.CheekPuffRight) / 2.0f;
            avatarParameters.MouthRaiserLower1 = vr.Values.MouthRaiserLower;
            avatarParameters.MouthRaiserLower2 = vr.Values.MouthRaiserUpper;
            avatarParameters.MouthRaiserLower4 = (vr.Values.MouthRaiserLower + vr.Values.MouthRaiserUpper) / 2.0f;
            avatarParameters.JawForward1 = vr.Values.JawForward;
            //avatarParameters.JawForward2 = valueReaders.Values.JawBackward;
            //avatarParameters.JawForward4 = (valueReaders.Values.JawForward + valueReaders.Values.JawBackward) / 2.0f;
            //avatarParameters.TongueOut1 = valueReaders.Values.Ton;
            //avatarParameters.TongueOut2 = valueReaders.Values.TongueIn;
            //avatarParameters.TongueOut4 = (valueReaders.Values.Ton + valueReaders.Values.TongueIn) / 2.0f;
            avatarParameters.NoseSneer1 = vr.Values.NoseSneerLeft;
            avatarParameters.NoseSneer2 = vr.Values.NoseSneerRight;
            avatarParameters.NoseSneer4 = (vr.Values.NoseSneerLeft + vr.Values.NoseSneerRight) / 2.0f;
            avatarParameters.MouthStretchLeft1 = vr.Values.MouthStretchLeft;
            avatarParameters.MouthStretchLeft2 = vr.Values.MouthStretchRight;
            avatarParameters.MouthStretchLeft4 = (vr.Values.MouthStretchLeft + vr.Values.MouthStretchRight) / 2.0f;
            avatarParameters.LipSuckUpper1 = vr.Values.LipSuckUpperLeft;
            avatarParameters.LipSuckUpper2 = vr.Values.LipSuckUpperRight;
            avatarParameters.LipSuckUpper4 = (vr.Values.LipSuckUpperLeft + vr.Values.LipSuckUpperRight) / 2.0f;
            avatarParameters.LipSuckLower1 = vr.Values.LipSuckLowerLeft;
            avatarParameters.LipSuckLower2 = vr.Values.LipSuckLowerRight;
            avatarParameters.LipSuckLower4 = (vr.Values.LipSuckLowerLeft + vr.Values.LipSuckLowerRight) / 2.0f;
            //avatarParameters.BrowExpressionLeft1 = valueReaders.Values.Browup;
            //avatarParameters.BrowExpressionLeft2 = valueReaders.Values.BrowLowererLeft;
            //avatarParameters.BrowExpressionLeft4 = (valueReaders.Values.Browup + valueReaders.Values.BrowLowererLeft) / 2.0f;
            //avatarParameters.BrowExpressionRight1 = valueReaders.Values.Brow;
            //avatarParameters.BrowExpressionRight2 = valueReaders.Values.BrowOuterUpRight;
            //avatarParameters.BrowExpressionRight4 = (valueReaders.Values.BrowInnerUp + valueReaders.Values.BrowOuterUpRight) / 2.0f;
            //avatarParameters.Brow
        }

        private static void SendParameters(OscClient oscClient, VRChatFTv2AvatarParameters avatarParameters) {
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckLower4, avatarParameters.LipSuckLower4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckLower2, avatarParameters.LipSuckLower2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckLower1, avatarParameters.LipSuckLower1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckUpper4, avatarParameters.LipSuckUpper4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckUpper2, avatarParameters.LipSuckUpper2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipSuckUpper1, avatarParameters.LipSuckUpper1);

            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionRight4, avatarParameters.BrowExpressionRight4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionRight2, avatarParameters.BrowExpressionRight2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionRight1, avatarParameters.BrowExpressionRight1);

            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionLeft4, avatarParameters.BrowExpressionLeft4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionLeft2, avatarParameters.BrowExpressionLeft2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.BrowExpressionLeft1, avatarParameters.BrowExpressionLeft1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchRight4, avatarParameters.MouthStretchRight4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchRight2, avatarParameters.MouthStretchRight2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchRight1, avatarParameters.MouthStretchRight1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchLeft4, avatarParameters.MouthStretchLeft4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchLeft2, avatarParameters.MouthStretchLeft2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthStretchLeft1, avatarParameters.MouthStretchLeft1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.NoseSneer4, avatarParameters.NoseSneer4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.NoseSneer2, avatarParameters.NoseSneer2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.NoseSneer1, avatarParameters.NoseSneer1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.TongueOut4, avatarParameters.TongueOut4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.TongueOut2, avatarParameters.TongueOut2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.TongueOut1, avatarParameters.TongueOut1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawForward4, avatarParameters.JawForward4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawForward2, avatarParameters.JawForward2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawForward1, avatarParameters.JawForward1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthRaiserLower4, avatarParameters.MouthRaiserLower4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthRaiserLower2, avatarParameters.MouthRaiserLower2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthRaiserLower1, avatarParameters.MouthRaiserLower1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.CheekPuffLeft4, avatarParameters.CheekPuffLeft4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.CheekPuffLeft2, avatarParameters.CheekPuffLeft2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.CheekPuffLeft1, avatarParameters.CheekPuffLeft1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthXNegative, avatarParameters.MouthXNegative);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthX8, avatarParameters.MouthX8);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthX4, avatarParameters.MouthX4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthX2, avatarParameters.MouthX2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthX1, avatarParameters.MouthX1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawXNegative, avatarParameters.JawXNegative);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawX4, avatarParameters.JawX4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawX2, avatarParameters.JawX2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawX1, avatarParameters.JawX1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipFunnel4, avatarParameters.LipFunnel4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipFunnel2, avatarParameters.LipFunnel2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipFunnel1, avatarParameters.LipFunnel1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipPucker4, avatarParameters.LipPucker4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipPucker2, avatarParameters.LipPucker2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.LipPucker1, avatarParameters.LipPucker1);

            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownLeft4, avatarParameters.SmileFrownLeft4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownLeft2, avatarParameters.SmileFrownLeft2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownLeft1, avatarParameters.SmileFrownLeft1);

            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownRight4, avatarParameters.SmileFrownRight4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownRight2, avatarParameters.SmileFrownRight2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.SmileFrownRight1, avatarParameters.SmileFrownRight1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthLowerDown4, avatarParameters.MouthLowerDown4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthLowerDown2, avatarParameters.MouthLowerDown2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthLowerDown1, avatarParameters.MouthLowerDown1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthClosed, avatarParameters.MouthClosed);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.MouthUpperUp, avatarParameters.MouthUpperUp);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.JawOpen, avatarParameters.JawOpen);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintRight4, avatarParameters.EyeSquintRight4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintRight2, avatarParameters.EyeSquintRight2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintRight1, avatarParameters.EyeSquintRight1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintLeft4, avatarParameters.EyeSquintLeft4);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintLeft2, avatarParameters.EyeSquintLeft2);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeSquintLeft1, avatarParameters.EyeSquintLeft1);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeLidRight, avatarParameters.EyeLidRight);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeLidLeft, avatarParameters.EyeLidLeft);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeY, avatarParameters.EyeY);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeRightX, avatarParameters.EyeRightX);
            oscClient.Send(VRChatFTv2AvatarParameterAddresses.EyeLeftX, avatarParameters.EyeLeftX);
        }

        private static void Listener(OSCQueryServiceProfile obj) {
            if (obj.serviceType != OSCQueryServiceProfile.ServiceType.OSC) { return; }
            if (!obj.name.StartsWith("VRChat-Client")) { return; }
            Console.WriteLine($"Found VRChat on {obj.address}:{obj.port}");
            VRCAddress = obj.address;
            VRCPort = obj.port;
            VRCReady = true;
        }
    }
}