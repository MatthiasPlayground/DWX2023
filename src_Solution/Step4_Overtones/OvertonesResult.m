overtoneOutput = load ("-ascii", "C:/Temp/TestOvertonesOut_BlackmanHarris_8192.dat");

index = overtoneOutput (:,1);
overtonesFrequencies = overtoneOutput (:,2);
overtoneLoudness = overtoneOutput (:,3);
overtonedB = overtoneOutput (:,4);


# bar(overtonesFrequencies, overtoneLoudness);
stairs(overtonesFrequencies, overtoneLoudness);


title('Obertöne - Raw');
xlabel('Frequenz Hz');
ylabel('Lautstärke');

axis([0 6000]);

print -demf ./Output/OvertonesRaw.emf    # Linux und Windows
print -dsvg ./Output/OvertonesRaw.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


# bar(overtonesFrequencies, overtonedB);
stairs(overtonesFrequencies, overtonedB);

title('Obertöne - dB');
xlabel('Frequenz Hz');
ylabel('Lautstärke dB');

axis([0 6000]);

print -demf ./Output/OvertonesdB.emf    # Linux und Windows
print -dsvg ./Output/OvertonesdB.svg    # Linux und Windows


