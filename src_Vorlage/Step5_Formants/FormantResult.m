formantOutput = load ("-ascii", "T:/TestFormantOut_BlackmanHarris_8192.dat");
overtoneOutput = load ("-ascii", "T:/TestOvertonesOut_BlackmanHarris_8192.dat");

newplot();

formantFrequencies = formantOutput (:,2);
formantLoudness = formantOutput (:,3);
formantdB = formantOutput (:,4);
overtonesFrequencies = overtoneOutput (:,2);
overtoneLoudness = overtoneOutput (:,3);
overtonedB = overtoneOutput (:,4);

[ox, oy] = stairs(overtonesFrequencies, overtoneLoudness);

hold on;
plot(ox, oy);
plot(formantFrequencies, formantLoudness, "o", "markersize", 5, "marker", 'o', 'color', [1.0 0.0 0.4]);
hold off;

title('Formanten - Raw');
xlabel('Frequenz Hz');
ylabel('Lautstärke');
# legend ("Obertöne;Formanten");

axis([0 6000]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FormantsRaw.emf    # Linux und Windows
print -dsvg ./Output/FormantsRaw.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


[ox, oy] = stairs(overtonesFrequencies, overtonedB);

hold on;
plot(ox, oy);
plot(formantFrequencies, formantdB, "o", "markersize", 5, "marker", 'o', 'color', [1.0 0.0 0.4]);
hold off;


title('Formanten - dB');
xlabel('Frequenz Hz');
ylabel('Lautstärke dB');
# legend ("Obertöne;Formanten");

axis([0 6000]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FormantsdB.emf    # Linux und Windows
print -dsvg ./Output/FormantsdB.svg    # Linux und Windows


