# Packet-Transmission
This application that uses serial port communication to transmit packets with CRC error checking. 

The user must have COM ports configured as follows:
> Local bridge between COM1 and COM2
> Split between COM2 to COM4 and COM5
> Shared COM1 shared as COM3

The user may use the application to configure open COM ports as follows:
> TX mode: COM3
> RX mode: COM4

A file is packetized, and transmitted through the serial port. If the user selects a No - Error mode or a mode with recovery, then a The file will be prompted to save on disk.

If a port sniffing application is used to view traffic between the serial ports, configure as follows:
> Sniffing: COM3
> Sniffing: COM5
