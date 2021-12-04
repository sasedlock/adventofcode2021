namespace DayOneFsTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open DayOneFs

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);

    [<TestMethod>]
    member this.ComparerCountsExpectedIncreasesFromTestInput () =
        let input = [199;200;208;210;200;207;240;269;260;263]
        let expected = 7
        let actual = Comparer.CountIncreasesInSequence input
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.ComparerCountsExpectedIncreasesWhenAllIncreasing () =
        let expected = 2
        let actual = Comparer.CountIncreasesInSequence [1;2;3]
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.ComparerReturnsZeroIfArrayHasOnlyOneElement () =
        let expected = 0
        let actual = Comparer.CountIncreasesInSequence []
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.ComparerGetsAnswerToDayOne () =
        let input = [|178;205;212;210;215;220;223;224;230;232;235;225;226;227;238;248;249;251;252;261;273;283;284;286;296;297;303;317;320;333;370;339;342;345;325;323;334;325;326;327;333;329;337;340;363;353;341;344;345;364;356;357;355;357;358;360;372;373;377;379;354;349;355;356;361;363;366;371;354;356;350;360;377;369;373;376;375;376;360;362;378;381;399;405;428;430;435;458;459;465;466;488;499;509;514;524;531;552;553;557;589;611;628;633;635;639;641;643;645;647;649;651;656;652;657;655;658;664;665;671;681;693;705;708;704;700;702;703;705;706;709;721;726;724;727;734;735;738;739;759;761;763;766;769;768;779;782;786;787;809;820;821;822;823;831;835;842;843;849;851;852;856;852;856;857;859;871;875;850;865;875;895;902;903;905;910;911;922;936;937;938;939;948;955;954;955;958;965;966;972;979;975;981;982;978;979;991;1009;1010;1009;988;985;989;990;999;1012;1013;1015;1018;1021;1038;1036;1051;1059;1076;1077;1081;1082;1111;1115;1114;1127;1129;1153;1156;1157;1163;1164;1168;1174;1180;1187;1188;1203;1207;1182;1183;1180;1181;1182;1180;1190;1189;1186;1187;1191;1207;1231;1246;1235;1240;1242;1244;1241;1245;1248;1251;1252;1260;1270;1273;1274;1270;1285;1281;1285;1306;1305;1304;1313;1318;1352;1371;1380;1379;1380;1382;1390;1394;1395;1408;1406;1407;1413;1425;1446;1447;1448;1450;1473;1482;1490;1488;1479;1484;1502;1507;1508;1509;1511;1512;1517;1520;1532;1536;1538;1537;1538;1539;1571;1574;1542;1548;1549;1550;1551;1549;1551;1563;1565;1558;1559;1589;1590;1591;1592;1593;1595;1573;1582;1608;1619;1625;1627;1638;1666;1665;1685;1687;1690;1700;1707;1714;1720;1729;1765;1767;1768;1752;1749;1764;1765;1774;1775;1777;1778;1787;1788;1789;1793;1794;1795;1800;1802;1808;1809;1803;1804;1815;1816;1823;1822;1828;1830;1835;1837;1846;1863;1865;1869;1872;1873;1876;1893;1894;1901;1903;1904;1900;1911;1913;1914;1916;1923;1946;1949;1951;1964;1965;1967;1978;2001;2004;2016;2021;2023;2026;2027;2029;2027;2028;2031;2041;2033;2041;2042;2034;2040;2043;2045;2058;2056;2061;2054;2064;2063;2068;2069;2073;2076;2077;2075;2077;2066;2067;2071;2072;2073;2077;2081;2082;2090;2086;2118;2122;2145;2151;2176;2177;2179;2189;2205;2218;2223;2248;2249;2250;2254;2247;2264;2265;2271;2272;2290;2292;2326;2328;2327;2328;2335;2338;2339;2347;2348;2349;2356;2353;2362;2363;2367;2369;2377;2384;2395;2397;2408;2409;2410;2409;2411;2407;2369;2372;2376;2378;2377;2382;2383;2384;2388;2390;2395;2393;2425;2418;2423;2446;2452;2464;2469;2473;2474;2472;2471;2473;2475;2476;2477;2479;2494;2500;2501;2502;2503;2534;2542;2541;2542;2560;2563;2570;2582;2577;2581;2579;2578;2586;2598;2599;2602;2606;2616;2618;2620;2622;2592;2595;2596;2629;2624;2626;2634;2635;2654;2655;2658;2630;2650;2661;2662;2663;2665;2686;2687;2690;2685;2696;2697;2704;2707;2709;2710;2711;2708;2712;2714;2717;2721;2719;2724;2729;2730;2761;2770;2772;2773;2791;2802;2803;2804;2798;2800;2803;2799;2796;2801;2804;2805;2814;2817;2801;2806;2807;2811;2829;2832;2820;2821;2858;2860;2863;2885;2889;2891;2892;2902;2913;2916;2917;2918;2919;2918;2927;2928;2932;2934;2951;2953;2954;2978;2981;3004;2999;3018;3017;3018;3019;3020;3018;3030;3040;3042;3046;3072;3087;3102;3141;3142;3163;3166;3179;3190;3191;3194;3197;3203;3220;3224;3232;3236;3255;3257;3261;3279;3278;3279;3284;3310;3330;3332;3334;3335;3365;3380;3381;3386;3373;3378;3398;3418;3422;3425;3427;3435;3442;3446;3447;3446;3448;3444;3445;3447;3448;3449;3453;3466;3467;3476;3479;3482;3483;3486;3500;3499;3501;3492;3490;3491;3493;3499;3501;3505;3490;3499;3500;3513;3514;3535;3550;3548;3549;3546;3547;3553;3554;3574;3575;3582;3583;3582;3585;3587;3600;3601;3605;3610;3609;3617;3598;3599;3601;3602;3585;3598;3615;3617;3623;3628;3631;3633;3636;3634;3635;3630;3617;3650;3652;3655;3660;3669;3685;3686;3674;3684;3685;3686;3694;3693;3694;3699;3708;3709;3722;3720;3724;3745;3740;3744;3762;3761;3783;3784;3785;3786;3781;3792;3797;3812;3814;3813;3788;3796;3795;3802;3805;3815;3816;3817;3818;3819;3822;3829;3833;3836;3847;3850;3851;3852;3850;3851;3870;3871;3873;3871;3874;3879;3888;3894;3900;3904;3907;3909;3912;3913;3921;3894;3896;3897;3898;3909;3914;3915;3913;3941;3945;3946;3947;3948;3954;3955;3980;3983;3985;3986;3993;3988;3992;3997;4002;4014;4022;4039;4044;4043;4040;4042;4053;4055;4066;4049;4070;4073;4081;4084;4085;4094;4107;4098;4107;4121;4140;4143;4144;4145;4156;4157;4174;4177;4163;4138;4143;4132;4118;4119;4120;4134;4137;4134;4168;4186;4190;4192;4202;4206;4214;4216;4217;4213;4217;4216;4238;4237;4245;4251;4255;4261;4276;4278;4282;4287;4290;4283;4277;4287;4290;4291;4292;4299;4302;4325;4326;4344;4339;4341;4343;4346;4345;4346;4348;4349;4350;4365;4364;4365;4367;4369;4373;4377;4375;4374;4400;4407;4409;4410;4413;4395;4400;4401;4404;4413;4408;4403;4405;4412;4417;4449;4469;4486;4492;4507;4513;4516;4517;4531;4540;4551;4561;4566;4568;4570;4571;4564;4572;4573;4575;4576;4605;4612;4602;4603;4608;4610;4617;4618;4620;4621;4622;4626;4639;4640;4661;4660;4658;4665;4664;4685;4686;4691;4694;4679;4684;4708;4709;4704;4721;4725;4727;4730;4731;4733;4741;4757;4759;4779;4786;4812;4818;4820;4836;4838;4839;4840;4844;4845;4851;4852;4858;4854;4860;4887;4853;4857;4867;4881;4883;4868;4869;4881;4862;4858;4860;4861;4862;4867;4872;4876;4892;4893;4894;4895;4897;4915;4924;4927;4929;4937;4938;4940;4943;4950;4957;4985;4984;4989;4978;4983;4984;4985;4978;4981;4983;4986;5012;5013;5014;5029;5031;5033;5034;5032;5033;5035;5037;5047;5049;5045;5048;5053;5055;5057;5071;5072;5070;5098;5091;5086;5072;5074;5076;5077;5078;5077;5078;5082;5085;5107;5135;5140;5142;5143;5146;5127;5130;5133;5144;5148;5150;5151;5158;5161;5165;5166;5172;5179;5180;5181;5179;5181;5211;5212;5217;5215;5216;5214;5234;5236;5239;5240;5253;5263;5276;5293;5305;5308;5313;5319;5324;5325;5328;5335;5337;5365;5352;5350;5352;5354;5355;5369;5375;5382;5387;5386;5393;5399;5403;5404;5406;5418;5423;5433;5434;5435;5436;5437;5438;5457;5454;5459;5460;5461;5463;5478;5490;5503;5512;5510;5517;5522;5525;5537;5553;5563;5553;5557;5563;5565;5573;5605;5579;5580;5581;5593;5596;5621;5612;5616;5621;5625;5633;5637;5647;5649;5661;5666;5657;5661;5664;5667;5679;5698;5699;5698;5706;5710;5712;5716;5692;5707;5709;5710;5711;5712;5713;5716;5730;5731;5732;5733;5736;5735;5737;5738;5740;5741;5742;5741;5748;5751;5759;5761;5766;5769;5781;5800;5801;5811;5813;5814;5813;5814;5821;5822;5821;5825;5844;5846;5858;5868;5875;5886;5889;5890;5896;5902;5905;5926;5925;5923;5897;5898;5924;5926;5943;5945;5956;5969;5980;5989;5998;6027;6028;6038;6039;6024;6026;6041;6058;6059;6063;6064;6068;6075;6081;6078;6059;6060;6088;6099;6104;6103;6104;6099;6100;6117;6113;6120;6121;6126;6157;6171;6172;6177;6178;6172;6173;6174;6179;6181;6191;6192;6197;6210;6209;6204;6205;6206;6215;6229;6232;6231;6241;6262;6263;6269;6270;6271;6278;6285;6287;6288;6289;6294;6298;6299;6312;6317;6323;6317;6318;6317;6319;6323;6322;6321;6325;6329;6348;6371;6368;6355;6332;6333;6342;6347;6351;6359;6346;6334;6331;6334;6355;6364;6365;6386;6391;6396;6370;6393;6395;6396;6399;6403;6411;6410;6417;6428;6429;6450;6426;6428;6429;6436;6437;6438;6464;6471;6475;6476;6483;6489;6490;6494;6490;6500;6501;6508;6516;6519;6520;6521;6524;6534;6541;6547;6549;6555;6556;6566;6568;6572;6586;6587;6590;6600;6605;6607;6609;6606;6605;6606;6616;6630;6640;6625;6624;6608;6618;6623;6627;6625;6646;6654;6655;6656;6659;6655;6656;6663;6658;6659;6657;6666;6667;6670;6671;6682;6662;6663;6664;6682;6692;6690;6704;6705;6712;6715;6719;6726;6727;6730;6728;6748;6759;6772;6773;6771;6773;6775;6766;6772;6784;6787;6789;6792;6795;6797;6799;6789;6790;6798;6800;6804;6803;6804;6797;6808;6814;6816;6819;6822;6833;6829;6830;6837;6839;6840;6842;6843;6849;6851;6853;6837;6843;6844;6849;6856;6858;6859;6857;6860;6862;6864;6863;6865;6870;6869;6849;6850;6855;6860;6856;6857;6867;6872;6874;6876;6866;6868;6877;6881;6882;6883;6893;6895;6896;6897;6910;6903;6904;6909;6910;6932;6930;6932;6944;6946;6966;6971;6972;6973;7000;7009;7011;7010;7021;7018;7017;7014;7018;7017;7020;7024;7027;7028;7030;7031;7037;7047;7056;7059;7061;7047;7074;7077;7078;7087;7116;7117;7127;7125;7101;7106;7112;7113;7125;7126;7129;7130;7133;7137;7138;7156;7158;7159;7158;7159;7160;7161;7163;7169;7172;7195;7196;7197;7199;7206;7218;7219;7222;7227;7239;7252;7256;7257;7249;7250;7256;7263;7267;7268;7279;7287;7290;7269;7268;7274;7278;7274;7282;7294;7295;7300;7299;7305;7297;7300;7301;7328;7360;7376;7365;7359;7362;7364;7373;7390;7398;7399;7407;7402;7401;7409;7411;7416;7408;7405;7408;7410;7414;7415;7418;7422;7428;7441;7442;7445;7454;7458;7460;7458;7467;7470;7501;7500;7501;7509;7521;7522;7523;7537;7540;7541;7551;7553;7554;7564;7565;7567;7563;7564;7580;7603;7604;7613;7614;7616;7627;7621;7630;7631;7641;7642;7652;7647;7646;7666;7690;7693;7691;7693;7699;7705;7682;7701;7703;7702;7710;7709;7711;7714;7713;7718;7727;7753;7756;7764;7782;7788;7787;7793;7794;7795;7767;7771;7776;7787;7791;7789;7790;7805;7804;7806;7814;7815;7816;7830;7832;7831;7830;7859;7878;7894;7896;7906;7927;7928;7929;7924;7929;7933;7934;7935;7946;7948;7950;7951;7973;7975;7976;7975;7974;7982;7964;7977;7967;7975;7973;7981;7999;8010;8017;8020;8021;8030;8055;8061;8069;8071;8072;8073;8082;8083;8096;8116;8122;8133;8134;8128;8136;8115;8122;8120;8126;8127;8134;8157;8158;8160;8164;8165;8179;8180;8186;8195;8205;8200;8197;8198;8199;8187;8193;8202;8214;8225;8224;8245;8235;8243;8244;8249;8250;8259;8264;8265;8273;8269;8273;8276;8278;8283;8284;8280;8294;8295;8296;8299;8300;8301;8302;8303;8305;8306;8310;8324;8326;8328;8335;8342;8344;8338;8341;8342;8348;8349;8351;8347;8355;8356;8357;8361;8364;8365;8372;8377;8392;8388;8387;8388;8394;8396;8407;8411;8426;8427;8426;8427;8430;8432;8435;8436;8437;8433;8428;8430;8431;8441;8442;8444;8441;8460;8464;8466;8459;8481;8486;8489;8462;8461;8478;8484;8483;8487;8488;8489;8513;8517;8518;8520;8534;8537;8538;8542;8546;8559;8564;8569;8582;8580;8582;8581;8586;8599;8605;8606;8593;8595;8600;8603;8608;8624;8632;8635;8640;8641;8642;8643;8662;8664;8674;8684;8685;8684;8692;8696;8701;8710;8691;8673;8674;8677;8675;8674;8669;8671;8670;8675;8678;8693;8697;8701;8702;8705;8713;8715;8720;8734;8741;8750;8753;8755|]
        let inputList = input |> Array.toList
        let expected = 1676
        let actual = Comparer.CountIncreasesInSequence inputList
        Assert.AreEqual(expected, actual)