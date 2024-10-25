import { createStore } from 'vuex'
import Pusher from 'pusher-js';
import router from "@/Router";

export default createStore({

    state () {
        return {
            UserConnected: null,
            userList: [],
            messagesList: [],
            holidayList: [],
            userHolidayList : []
        }
    },
    mutations: {
        setUserConnected(state, data) {
          state.UserConnected = data;
          localStorage.setItem('userConnected', JSON.stringify(data));
        },
        clearUserConnected(state) {
          state.UserConnected = null;
          localStorage.removeItem('userConnected');
        },
        addUser(state, user) {
          state.userList.push(user);
        },
        setUserList(state, list) {
          state.userList = list;
        },
        setHolidayList(state, list){
            state.holidayList = list;
        },
        setUserHolidayList(state, list){
            state.userHolidayList = list;
        },
        setMessages(state, msgs){
            state.messagesList = msgs
        },
        addMessage(state, msg){
            state.messagesList.push(msg)
        }
    },

    actions: {
        async login({ commit }, { email, password }) {
            try {
                const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Authentication', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({ email, password }),
                });

                if (!response.ok) {
                    let msg = await response.json().then(data => {return data})
                    throw new Error(msg.message)
                }

                const user = await response.json();
                commit('setUserConnected', user);
                await router.push({path: '/'})

            } catch (error) {
                throw new Error(error.message);
            }
        },

        async loginByOAuth({ commit }, { token }){
            try {
                console.log(JSON.stringify({ token }))
                const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Authentication/oauth', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({ token }),
                });

                if (!response.ok) {
                    throw new Error('Identifiants invalides');
                }

                const user = await response.json();
                commit('setUserConnected', user);
                await router.push({path: '/'})

            } catch (error) {
                throw new Error(error);
                //console.error('Erreur lors de la connexion:', error.message);
            }
        },

        async deconnexion({ commit }) {
            commit('clearUserConnected');
            await router.push({path: '/connexion'})
        },

        async fetchHolidays({commit}){
            const user = this.state.UserConnected
            if(user == null) return

            await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Holiday')
                .then(response => response.json())
                .then(data => {
                    commit('setHolidayList', data)
                })
                .catch(error => {
                    console.error('Erreur lors de la récupération de la globalité des vacances. Cause :', error);
                });

            await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/UserHoliday/user/${user.Id}`, {
                headers: {
                    'Authorization': `Bearer ${user.Token}`
                }})
                .then(response => response.json())
                .then(data => {
                    commit('setUserHolidayList', data)
                })
                .catch(error => {
                    console.error('Erreur lors de la récupération des vacances de l\'utilisateur. Cause :', error);
                });
        },

        async fetchMessages({commit}, {holidayId}){
            const user = this.state.UserConnected
            if(user == null) return

            await fetch(`https://porthos-intra.cg.helmo.be/Q210044/api/Chat/${holidayId}`, {
                headers: {
                    'Authorization': `Bearer ${user.Token}`
                }})
                .then(response => response.json())
                .then(data => {
                    console.log(data)
                    commit('setMessages', data)
                })
                .catch(error => {
                    console.error('Erreur lors de la récupération des messages. Cause :', error);
                });
        },

        async addMessage({commit}, msg){
            commit('addMessage', msg)
        },

        setUser({ commit }, data){
            commit('setUserConnected', data);
        },
      
    },
    getters: {
        getUserConnected: state => state.UserConnected,

        getUserList: state =>state.userList,

        getHolidays: state => state.holidayList,

        getUserHolidays: state => state.userHolidayList,

        getMessages: state => state.messagesList,

        isConnected: state =>state.UserConnected !== null
    }
  })