package main

import (
	"bufio"
	"fmt"
	"net"
	"strings"
)

const MIN = 1
const MAX = 100

func handleConnection(c net.Conn) {
	fmt.Printf("Got a connection from %s\n", c.RemoteAddr().String())
	for {
		netData, err := bufio.NewReader(c).ReadString('\n')
		if err != nil {
			fmt.Println(err)
			return
		}
		temp := strings.TrimSpace(string(netData))
		fmt.Printf("%s says: %s\n", c.RemoteAddr().String(), temp)
		temp = strings.ToLower(temp)
		if temp == "exit" {
			break
		} else if temp == "hi" {
			c.Write([]byte("Hello\n"))
		} else if temp == "what's up?" {
			c.Write([]byte("nothing\n"))
		} else if strings.HasPrefix(temp, "connect") {
			m := strings.Split(c.RemoteAddr().String(), ":")
			rip := m[0]
			n := strings.Split(temp, " ")
			rport := n[1]
			fmt.Printf("Trying to connect to %s:%s\n", rip, rport)
			rserver, err := net.ResolveUDPAddr("udp4", rip+":"+rport)
			if err != nil {
				fmt.Println("Couldn't resolve remote server", err.Error())
				break
			}
			u, err := net.DialUDP("udp4", nil, rserver)
			if err != nil {
				fmt.Println("Couldn't connect to remote server", err.Error())
				break
			}
			fmt.Printf("Connected to %s\n", u.RemoteAddr().String())
			_, err = u.Write([]byte("This is the first bit of data\n"))
			_, err = u.Write([]byte("This is the second line of data\n"))
			_, err = u.Write([]byte("EXIT\n"))
			fmt.Println("Sent Data!")
			u.Close()
			fmt.Println("Connection Closed")
		} else {
			c.Write([]byte("Unknown: " + string(netData)))
		}

	}
	c.Close()

}

func main() {
	PORT := ":8080"
	l, err := net.Listen("tcp4", PORT)
	if err != nil {
		fmt.Println(err)
		return
	}
	defer l.Close()

	for {
		c, err := l.Accept()
		if err != nil {
			fmt.Println(err)
			return
		}
		go handleConnection(c)
	}

}