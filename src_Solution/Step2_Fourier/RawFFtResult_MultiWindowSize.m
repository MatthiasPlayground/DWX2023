fftOutputHann512 = load ("-ascii", "C:/Temp/TestFFTOut_Hanning_512.dat");
fftOutputBlackman512 = load ("-ascii", "C:/Temp/TestFFTOut_Blackman-Harris_512.dat");
fftOutputHann2048 = load ("-ascii", "C:/Temp/TestFFTOut_Hanning_2048.dat");
fftOutputBlackman2048 = load ("-ascii", "C:/Temp/TestFFTOut_Blackman-Harris_2048.dat");
fftOutputHann8192 = load ("-ascii", "C:/Temp/TestFFTOut_Hanning_8192.dat");
fftOutputBlackman8192 = load ("-ascii", "C:/Temp/TestFFTOut_Blackman-Harris_8192.dat");

binHann1 = fftOutputHann512 (:,1);
hzHann1 = fftOutputHann512 (:,2);
fftStrengthHann1 = fftOutputHann512 (:,3);
fftStrengthdBHann1 = fftOutputHann512 (:,4);
binHann2 = fftOutputHann2048 (:,1);
hzHann2 = fftOutputHann2048 (:,2);
fftStrengthHann2 = fftOutputHann2048 (:,3);
fftStrengthdBHann2 = fftOutputHann2048 (:,4);
binHann3 = fftOutputHann8192 (:,1);
hzHann3 = fftOutputHann8192 (:,2);
fftStrengthHann3 = fftOutputHann8192 (:,3);
fftStrengthdBHann3 = fftOutputHann8192 (:,4);

binBlackman1 = fftOutputBlackman512 (:,1);
hzBlackman1 = fftOutputBlackman512 (:,2);
fftStrengthBlackman1 = fftOutputBlackman512 (:,3);
fftStrengthdBBlackman1 = fftOutputBlackman512 (:,4);
binBlackman2 = fftOutputBlackman2048 (:,1);
hzBlackman2 = fftOutputBlackman2048 (:,2);
fftStrengthBlackman2 = fftOutputBlackman2048 (:,3);
fftStrengthdBBlackman2 = fftOutputBlackman2048 (:,4);
binBlackman3 = fftOutputBlackman8192 (:,1);
hzBlackman3 = fftOutputBlackman8192 (:,2);
fftStrengthBlackman3 = fftOutputBlackman8192 (:,3);
fftStrengthdBBlackman3 = fftOutputBlackman8192 (:,4);

plot(hzHann1, fftStrengthHann1, "LineWidth", 1);
hold on
plot(hzHann2, fftStrengthHann2, "LineWidth", 1);
plot(hzHann3, fftStrengthHann3, "LineWidth", 1);
hold off

title('Fouriertransformation - Von Hann versch. Breite');
xlabel('Hz');
ylabel('y');
legend ("Von Hann 512", "Von Hann 2048", "Von Hann 8192");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultVonHannAbs.emf    # Linux und Windows
print -dsvg ./Output/FFTResultVonHannAbs.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


plot(hzBlackman1, fftStrengthBlackman1, "LineWidth", 1);
hold on
plot(hzBlackman2, fftStrengthBlackman2, "LineWidth", 1);
plot(hzBlackman3, fftStrengthBlackman3, "LineWidth", 1);
hold off

title('Fouriertransformation - Blackman versch. Breite');
xlabel('Hz');
ylabel('y');
legend ("Blackman 512", "Blackman 2048", "Blackman 8192");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultBlackmanAbs.emf    # Linux und Windows
print -dsvg ./Output/FFTResultBlackmanAbs.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


plot(hzHann1, fftStrengthHann1, "LineWidth", 1);
hold on
plot(hzHann3, fftStrengthHann3, "LineWidth", 1);
plot(hzBlackman3, fftStrengthBlackman3, "LineWidth", 1);
hold off

title('Fouriertransformation - Von Hann - Blackman');
xlabel('Hz');
ylabel('y');
legend ("Von Hann 512", "Von Hann 8192", "Blackman 8192");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultCompareAbs8192.emf    # Linux und Windows
print -dsvg ./Output/FFTResultCompareAbs8192.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


plot(hzHann1, fftStrengthdBHann1, "LineWidth", 1);
hold on
plot(hzHann3, fftStrengthdBHann3, "LineWidth", 1);
plot(hzBlackman3, fftStrengthdBBlackman3, "LineWidth", 1);
hold off

title('Fouriertransformation - Von Hann - Blackman (dB)');
xlabel('Hz');
ylabel('dB');
legend ("Von Hann 512", "Von Hann 8192", "Blackman 8192");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultComparedB8192.emf    # Linux und Windows
print -dsvg ./Output/FFTResultComparedB8192.svg    # Linux und Windows


