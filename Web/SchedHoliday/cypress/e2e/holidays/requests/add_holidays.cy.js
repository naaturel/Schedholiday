
var user = null

async function login({ email, password }) {
    try {
        const response = await fetch('https://porthos-intra.cg.helmo.be/Q210044/api/Authentication', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password }),
        });

        return await response.json();

    } catch (error) {
        throw new Error(error.message);
    }
}

describe('', () =>{

    before(async () => {
        user = await login({email : "auva@gmail.com", password:"Password_123"})
        console.log(user)
    })

    beforeEach(() => {
        cy.visit("http://localhost:5173/")
    })

    it('Add holiday successfully', async () => {

        cy.request({
            method: 'POST',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Holiday',
            headers : {
                authorization : `Bearer ${user.Token}`
            },
            body : {
                name: "Cypress holiday",
                creatorId: user.Id,
                epochStart: 1803285999,
                epochEnd: 1803286000,
                longitude: 42,
                latitude: 42
            },
            failOnStatusCode : false
        })
            .should((response) => {
                expect(response.status).to.eq(200)
            })

    })

})