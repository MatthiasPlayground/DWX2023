fftOutputHann = load ("-ascii", "C:/Temp/TestFFTOut_Hanning_512.dat");
fftOutputBlackman = load ("-ascii", "C:/Temp/TestFFTOut_Blackman-Harris_512.dat");

binHann = fftOutputHann (:,1);
fftStrengthHann = fftOutputHann (:,3);
fftStrengthdBHann = fftOutputHann (:,4);
binBlackman = fftOutputBlackman (:,1);
fftStrengthBlackman = fftOutputBlackman (:,3);
fftStrengthdBBlackman = fftOutputBlackman (:,4);

plot(binHann, fftStrengthHann, "LineWidth", 1);
hold on
plot(binBlackman, fftStrengthBlackman, "LineWidth", 1);
hold off

title('Fouriertransformation - Vergleich Von Hann - Blackman');
xlabel('bin');
ylabel('y');
legend ("Von Hann", "Blackman");

# axis([0 8000]);

print -demf ./Output/FFTResultCompareAbs.emf    # Linux und Windows
print -dsvg ./Output/FFTResultCompareAbs.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


plot(binHann, fftStrengthdBHann, "LineWidth", 1);
hold on
plot(binBlackman, fftStrengthdBBlackman, "LineWidth", 1);
hold off

title('Fouriertransformation - Vergleich Von Hann - Blackman (dB)');
xlabel('bin');
ylabel('dB');
legend ("Von Hann", "Blackman");

# axis([0 8000]);

print -demf ./Output/FFTResultComparedB.emf    # Linux und Windows
print -dsvg ./Output/FFTResultComparedB.svg    # Linux und Windows


