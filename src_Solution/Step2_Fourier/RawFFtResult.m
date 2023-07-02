# fftOutput = load ("-ascii", "C:/Temp/TestFFTOut_Hanning_512.dat");
fftOutput = load ("-ascii", "C:/Temp/TestFFTOut_Blackman-Harris_8192.dat");

bin = fftOutput (:,1);
fftStrength = fftOutput (:,3);
fftStrengthdB = fftOutput (:,4);


plot(bin, fftStrength, "LineWidth", 1);

title('Fouriertransformation - Raw');
xlabel('bin');
ylabel('y');
# legend ("abs()");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultAbs.emf    # Linux und Windows
print -dsvg ./Output/FFTResultAbs.svg    # Linux und Windows

pause (3);  # 3 Sekunden warten
newplot();


plot(bin, fftStrengthDb, "LineWidth", 1);

title('Fouriertransformation - dB');
xlabel('bin');
ylabel('dB');
# legend ("abs()");

# axis([-20 20 -40 0]);
# set(gca, 'XTick', [-20:20])
# set(gca, 'YTick', [-40:0])

print -demf ./Output/FFTResultdB.emf    # Linux und Windows
print -dsvg ./Output/FFTResultdB.svg    # Linux und Windows


