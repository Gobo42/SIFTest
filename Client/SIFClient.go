package main

import (
	"bufio"
	"fmt"
	"net"
	"os"
	"strings"
)

func main() {
	fmt.Print("Server IP: ")
	reader := bufio.NewReader(os.Stdin)
	server, _ := reader.ReadString('\n')
	server = strings.TrimSpace(server) + ":8080"
	tcpAddr, err := net.ResolveTCPAddr("tcp", server)
	if err != nil {
		fmt.Println("Resolve failed:", err.Error())
		os.Exit(1)
	}

	conn, err := net.DialTCP("tcp", nil, tcpAddr)
	if err != nil {
		fmt.Println("Connect failed:", err.Error())
		os.Exit(1)
	}

	for {
		fmt.Print("Command to send: ")

		temp, _ := reader.ReadString('\n')
		_, err = conn.Write([]byte(temp))
		if err != nil {
			fmt.Println("Failed to write to server:", err.Error())
			os.Exit(1)
		}
		temp = strings.TrimSpace(temp)
		fmt.Println("Sending:", temp)
		if temp == "STOP" {
			fmt.Println("Stopping...")
			break
		}
		temp = strings.ToLower(temp)
		if strings.HasPrefix(temp, "connect") {
			m := strings.Split(temp, " ")
			fmt.Printf("starting listener on port %s\n", m[1])
			l, err := net.ResolveUDPAddr("udp4", ":"+m[1])
			if err != nil {
				fmt.Println("couldn't resolve ", m[1])
				os.Exit(2)
			}
			conn, err := net.ListenUDP("udp", l)
			if err != nil {
				fmt.Println("Couldn't open ", l, " for listening: ", err.Error())
				os.Exit(2)
			}
			for {
				message := make([]byte, 1024)
				rlen, remote, err := conn.ReadFromUDP(message[:])
				if err != nil {
					panic(err)
				}
				data := strings.TrimSpace(string(message[:rlen]))
				fmt.Printf("Got \"%s\" from %s\n", data, remote)
				if data == "EXIT" {
					break
				}
			}
			fmt.Println("Done getting stuff from server.")
			conn.Close()
		} else {
			reply := make([]byte, 1024)
			_, err = conn.Read(reply)
			if err != nil {
				fmt.Println("Couldn't get reply", err.Error())
				os.Exit(1)
			}
			fmt.Print("Reply from server:", string(reply))
		}
	}
	conn.Close()
}
