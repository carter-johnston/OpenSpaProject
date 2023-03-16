<script lang="ts">
    import Tab from "$lib/components/Tab.svelte";   
</script>

<h1 class="font-sans font-thin text-3xl text-center">Welcome to SvelteKit</h1>
<Tab>
    <p>Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation</p>
</Tab>

<style lang="postcss">
    :global(html) {
        background-color: theme(colors.gray.100);
    }
</style>